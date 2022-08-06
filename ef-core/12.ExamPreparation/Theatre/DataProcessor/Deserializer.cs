using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using AutoMapper;

using Newtonsoft.Json;

using Theatre.Data;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Theatre.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlayDto[]), root);
            
            using StringReader reader = new StringReader(xmlString);
            ImportPlayDto[] playDtos = (ImportPlayDto[])serializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            ICollection<Play> plays = new List<Play>();
            foreach (ImportPlayDto dto in playDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration = TimeSpan.ParseExact(dto.Duration, "c", CultureInfo.InvariantCulture);
                if (duration.TotalMinutes < 60)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse(typeof(Genre), dto.Genre, out object genreObj);
                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play
                {
                    Title = dto.Title,
                    Duration = duration,
                    Rating = dto.Rating,
                    Genre = (Genre)genreObj,
                    Description = dto.Description,
                    Screenwriter = dto.Screenwriter
                };

                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastDto[]), root);

            using StringReader reader = new StringReader(xmlString);
            ImportCastDto[] castDtos = (ImportCastDto[])serializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            ICollection<Cast> casts = new List<Cast>();
            foreach (ImportCastDto dto in castDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast
                {
                    FullName = dto.FullName,
                    IsMainCharacter = dto.IsMainCharacter,
                    PhoneNumber = dto.PhoneNumber,
                    PlayId = dto.PlayId
                };

                casts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportTheaterDto[] teatreDtos = JsonConvert.DeserializeObject<ImportTheaterDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            ICollection<Data.Models.Theatre> theaters = new List<Data.Models.Theatre>();
            foreach (ImportTheaterDto dto in teatreDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Data.Models.Theatre theater = new Data.Models.Theatre
                {
                    Name = dto.Name,
                    NumberOfHalls = dto.NumberOfHalls,
                    Director = dto.Director,
                };

                foreach (ImportTicketDto ticket in dto.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    theater.Tickets.Add(Mapper.Map<Ticket>(ticket));
                }

                theaters.Add(theater);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theater.Name, theater.Tickets.Count));
            }

            context.Theatres.AddRange(theaters);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validator = new ValidationContext(obj);
            List<ValidationResult> validationRes = new List<ValidationResult>();

            bool result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
