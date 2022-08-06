using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using Footballers.Data;
using Footballers.DataProcessor.ExportDto;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            ExportCoachWithFootballerDto[] coachesDto = context.Coaches
                .ToArray()
                .Where(c => c.Footballers.Count >= 1)
                .Select(c => new ExportCoachWithFootballerDto
                {
                    FootballersCount = c.Footballers.Count,
                    Name = c.Name,
                    Footballers = c.Footballers
                        .Select(f => new GetFootballerDto
                        {
                            Name = f.Name,
                            PositionType = f.PositionType.ToString()
                        })
                        .OrderBy(f => f.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.Name)
                .ToArray();

            ExportCoachWithFootballerDto[] coachesDtoSplit = coachesDto
                .Where(c => c.FootballersCount >= 1)
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.Name)
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Coaches");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCoachWithFootballerDto[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter();
            serializer.Serialize(writer, coachesDtoSplit, namespaces);

            return writer.ToString().Trim();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Include(db => db.TeamsFootballers)
                .Where(t => t.TeamsFootballers.Count >= 1)
                .ToArray()
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .ToArray()
                        .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                        .ThenBy(tf => tf.Footballer.Name)
                        .Select(tf => new
                        {
                            FootballerName = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })
                })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
