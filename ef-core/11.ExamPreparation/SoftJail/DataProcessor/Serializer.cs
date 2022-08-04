using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using SoftJail.Data;
using SoftJail.DataProcessor.ExportDto;

namespace SoftJail.DataProcessor
{
    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Include(db => db.PrisonerOfficers)
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    p.Id,
                    Name = p.FullName,
                    p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(op => new
                        {
                            OfficerName = op.Officer.FullName,
                            Department = op.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(op => op.Officer.Salary), 2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] names = prisonersNames.Split(',');

            ExportPrisonerInboxDto[] prisonerDtos = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .ProjectTo<ExportPrisonerInboxDto>()
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Prisoners");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportPrisonerInboxDto[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter();
            serializer.Serialize(writer, prisonerDtos, namespaces);

            return writer.ToString().Trim();
        }
    }
}
