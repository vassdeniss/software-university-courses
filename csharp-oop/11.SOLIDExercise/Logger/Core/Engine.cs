using Logger.Appenders;
using Logger.Enums;
using Logger.Factories;
using Logger.Layouts;
using Logger.LogFiles;
using Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger.Core
{
    public class Engine : IRunnable
    {
        public void Run()
        {
            CommandInterpeter();
            return;

            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            ILayout xmlLayout = new XmlLayout();
            ILogFile file = new LogFile();
            IAppender fileAppender = new FileAppender(xmlLayout, file);

            consoleAppender.ReportLevel = ReportLevel.Info;
            fileAppender.ReportLevel = ReportLevel.Fatal;

            ILogger logger = new Loggers.Logger(consoleAppender, fileAppender);

            logger.Info("User Pesho successfully registered.");
            logger.Error("Error parsing JSON.");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }

        private void CommandInterpeter()
        {
            List<IAppender> appenders = new List<IAppender>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string appenderType = tokens[0];
                string layoutType = tokens[1];
                ReportLevel level = tokens.Length == 3
                    ? Enum.Parse<ReportLevel>(tokens[2], true)
                    : ReportLevel.Fatal;

                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, level);

                appenders.Add(appender);
            }

            ILogger logger = new Loggers.Logger(appenders.ToArray());

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] messageInfo = command.Split('|');

                ReportLevel level = Enum.Parse<ReportLevel>(messageInfo[0], true);
                DateTime time = DateTime.Parse(messageInfo[1]);
                string message = messageInfo[2];

                switch (level)
                {
                    case ReportLevel.Fatal: logger.Fatal(message); break;
                    case ReportLevel.Critical: logger.Critical(message); break;
                    case ReportLevel.Error: logger.Error(message); break;
                    case ReportLevel.Warning: logger.Warn(message); break;
                    default: logger.Info(message); break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Logger info");
            logger.Appenders.ToList().ForEach(Console.WriteLine);
        }
    }
}
