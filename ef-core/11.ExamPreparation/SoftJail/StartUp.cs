using System;
using System.IO;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SoftJail.Data;

namespace SoftJail
{
    public class StartUp
    {
        public static void Main()
        {
            SoftJailDbContext context = new SoftJailDbContext();

            Mapper.Initialize(config => config.AddProfile<SoftJailProfile>());

            ResetDatabase(context, shouldDropDatabase: false);

            string projectDir = GetProjectDirectory();

            ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");
            ExportEntities(context, projectDir + @"ExportResults/");

            using var transaction = context.Database.BeginTransaction();
            transaction.Rollback();
        }

        private static void ImportEntities(SoftJailDbContext context, string baseDir, string exportDir)
        {
            string departmentsCells =
                DataProcessor.Deserializer.ImportDepartmentsCells(context,
                    File.ReadAllText(baseDir + "ImportDepartmentsCells.json"));
            PrintAndExportEntityToFile(departmentsCells, exportDir + "ImportDepartmentsCells.txt");

            string prisonersMails =
                DataProcessor.Deserializer.ImportPrisonersMails(context,
                    File.ReadAllText(baseDir + "ImportPrisonersMails.json"));
            PrintAndExportEntityToFile(prisonersMails, exportDir + "ImportPrisonersMails.txt");

            string officersPrisoners = DataProcessor.Deserializer.ImportOfficersPrisoners(context, File.ReadAllText(baseDir + "ImportOfficersPrisoners.xml"));
            PrintAndExportEntityToFile(officersPrisoners, exportDir + "ImportOfficersPrisoners.txt");
        }

        private static void ExportEntities(SoftJailDbContext context, string exportDir)
        {
            string jsonOutput = DataProcessor.Serializer.ExportPrisonersByCells(context, new[] { 1, 5, 7, 3 });
            Console.WriteLine(jsonOutput);
            File.WriteAllText(exportDir + "PrisonersByCells.json", jsonOutput);

            string xmlOutput = DataProcessor.Serializer.ExportPrisonersInbox(context, "Melanie Simonich,Diana Ebbs,Binni Cornhill");
            Console.WriteLine(xmlOutput);
            File.WriteAllText(exportDir + "PrisonersInbox.xml", xmlOutput);
        }
        private static void ResetDatabase(SoftJailDbContext context, bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                context.Database.EnsureDeleted();
            }

            if (context.Database.EnsureCreated())
            {
                return;
            }

            string disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlCommand(disableIntegrityChecksQuery);

            string deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
            context.Database.ExecuteSqlCommand(deleteRowsQuery);

            string enableIntegrityChecksQuery =
                "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlCommand(enableIntegrityChecksQuery);

            string reseedQuery =
                "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
            context.Database.ExecuteSqlCommand(reseedQuery);
        }

        private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
        {
            Console.WriteLine(entityOutput);
            File.WriteAllText(outputPath, entityOutput.TrimEnd());
        }

        private static string GetProjectDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string directoryName = Path.GetFileName(currentDirectory);
            string relativePath = directoryName.StartsWith("netcoreapp") ? @"../../../" : string.Empty;

            return relativePath;
        }
    }
}
