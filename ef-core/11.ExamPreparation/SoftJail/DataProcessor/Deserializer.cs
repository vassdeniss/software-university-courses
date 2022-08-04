using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using AutoMapper;

using Newtonsoft.Json;

using SoftJail.Data;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{
    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            ImportDepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            ICollection<Department> departments = new List<Department>();
            foreach (ImportDepartmentDto dto in departmentDtos)
            {
                if (!IsValid(dto) 
                    || dto.Cells.Any(dto => !IsValid(dto))
                    || dto.Cells.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department dep = Mapper.Map<Department>(dto);
                departments.Add(dep);
                sb.AppendLine($"Imported {dep.Name} with {dep.Cells.Count} cells");
            }
 
            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            ImportPrisonerDto[] mailDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            ICollection<Prisoner> prisoners = new List<Prisoner>();
            foreach (ImportPrisonerDto dto in mailDtos)
            {
                if (!IsValid(dto) 
                    || dto.Mails.Any(dto => !IsValid(dto)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Mail[] mails = Mapper.Map<Mail[]>(dto.Mails);

                bool isIncarcerationDateValid = DateTime.TryParseExact(dto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);
                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;
                if (!string.IsNullOrEmpty(dto.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime.TryParseExact(dto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateValue);
                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner
                {
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    Age = dto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = dto.Bail,
                    CellId = dto.CellId,
                    Mails = mails
                };

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {dto.FullName} {dto.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            ImportOfficerDto[] officerDtos = DeserializeXml<ImportOfficerDto>("Officers", xmlString);

            StringBuilder sb = new StringBuilder();
            ICollection<Officer> officers = new List<Officer>();
            foreach (ImportOfficerDto dto in officerDtos)
            {
                bool isPositionValid = Enum.TryParse(typeof(Position), dto.Position, out object positionObj);
                if (!isPositionValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isWeaponValid = Enum.TryParse(typeof(Weapon), dto.Weapon, out object weaponObj);
                if (!isWeaponValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = dto.FullName,
                    Salary = dto.Salary,
                    Position = (Position)positionObj,
                    Weapon = (Weapon)weaponObj,
                    DepartmentId = dto.DepartmentId
                };

                foreach (ImportPrisonerXmlDto innerDto in dto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        Officer = officer,
                        PrisonerId = innerDto.Id
                    });
                }

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static T[] DeserializeXml<T>(string xmlRoot, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute(xmlRoot);
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), root);

            using StringReader reader = new StringReader(inputXml);
            T[] dtos = (T[])serializer.Deserialize(reader);

            return dtos;
        }

        private static bool IsValid(object obj)
        {
            System.ComponentModel.DataAnnotations.ValidationContext validationContext 
                = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}
