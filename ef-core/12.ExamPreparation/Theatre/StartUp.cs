using System;
using System.IO;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Theatre.Data;

namespace Theatre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            TheatreContext context = new TheatreContext();

            Mapper.Initialize(config => config.AddProfile<TheatreProfile>());

            ResetDatabase(context, shouldDropDatabase: true);

            string projectDir = GetProjectDirectory();

            ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");

            ExportEntities(context, projectDir + @"ExportResults/");

            using var transaction = context.Database.BeginTransaction();
            transaction.Rollback();
        }

        private static void ImportEntities(TheatreContext context, string baseDir, string exportDir)
        {
            string theatersAndTickets =
              DataProcessor.Deserializer.ImportPlays(context,
                  File.ReadAllText(baseDir + "plays.xml"));
            PrintAndExportEntityToFile(theatersAndTickets, exportDir + "Actual Result - ImportPlays.txt");

            string casts = DataProcessor.Deserializer.ImportCasts(context,
               File.ReadAllText(baseDir + "casts.xml"));
            PrintAndExportEntityToFile(casts, exportDir + "Actual Result - ImportCasts.txt");

            string plays =
                DataProcessor.Deserializer.ImportTtheatersTickets(context,
                    File.ReadAllText(baseDir + "theatres-and-tickets.json"));
            PrintAndExportEntityToFile(plays, exportDir + "Actual Result - ImportTheatresTickets.txt");

        }

        private static void ExportEntities(TheatreContext context, string exportDir)
        {
            string exportTheaters = DataProcessor.Serializer.ExportTheatres(context, 6);
            Console.WriteLine(exportTheaters);
            File.WriteAllText(exportDir + "Actual Result - ExportTheatres.json", exportTheaters);

            string exportPlays = DataProcessor.Serializer.ExportPlays(context, 7.5);
            Console.WriteLine(exportPlays);
            File.WriteAllText(exportDir + "Actual Result - ExportPlays.xml", exportPlays);
        }

        private static void ResetDatabase(TheatreContext context, bool shouldDropDatabase = false)
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
            context.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

            string deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
            context.Database.ExecuteSqlRaw(deleteRowsQuery);

            string enableIntegrityChecksQuery =
                "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

            string reseedQuery =
                "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
            context.Database.ExecuteSqlRaw(reseedQuery);
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
