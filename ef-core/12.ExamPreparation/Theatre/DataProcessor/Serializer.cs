using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Theatre.Data;
using Theatre.DataProcessor.ExportDto;

namespace Theatre.DataProcessor
{
    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .Include(t => t.Tickets)
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(tt => tt.RowNumber >= 1 && tt.RowNumber <= 5)
                        .Sum(tt => tt.Price),
                    Tickets = t.Tickets
                        .Where(tt => tt.RowNumber >= 1 && tt.RowNumber <= 5)
                        .Select(tt => new
                        {
                            Price = decimal.Parse(tt.Price.ToString("f2")),
                            tt.RowNumber
                        })
                        .OrderByDescending(tt => tt.Price)
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            ExportPlayDto[] playDtos = context.Plays
                .Where(p => p.Rating <= rating)
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ProjectTo<ExportPlayDto>()
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportPlayDto[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter();
            serializer.Serialize(writer, playDtos, namespaces);

            return writer.ToString().Trim();
        }
    }
}
