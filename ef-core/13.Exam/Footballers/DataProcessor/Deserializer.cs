using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Footballers.Data;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;

using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Coaches");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachDto[]), root);

            using StringReader reader = new StringReader(xmlString);
            ImportCoachDto[] coachDtos = (ImportCoachDto[])serializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            ICollection<Coach> coaches = new List<Coach>();
            foreach (ImportCoachDto dto in coachDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality
                };

                foreach (ImportFootballerDto innerDto in dto.Footballers)
                {
                    if (!IsValid(innerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isPositionValid = Enum.TryParse(typeof(PositionType), innerDto.PositionType, out object positionObj);
                    if (!isPositionValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isSkillValid = Enum.TryParse(typeof(BestSkillType), innerDto.BestSkillType, out object skillObj);
                    if (!isSkillValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractStartDateValid = DateTime.TryParseExact(innerDto.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractStartDate);
                    if (!isContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractEndDateValid = DateTime.TryParseExact(innerDto.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractEndDate);
                    if (!isContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractEndDate < contractStartDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    coach.Footballers.Add(new Footballer
                    {
                        Name = innerDto.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        PositionType = (PositionType)positionObj,
                        BestSkillType = (BestSkillType)skillObj,
                    });
                }

                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            ICollection<Team> teams = new List<Team>();
            foreach (ImportTeamDto dto in teamDtos)
            {
                if (!IsValid(dto) || dto.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                    Trophies = dto.Trophies
                };

                foreach (int id in dto.Footballers.Distinct())
                {
                    if (context.Footballers.Find(id) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer
                    {
                        FootballerId = id,
                        Team = team
                    });
                }

                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
