using Logger.Appenders;
using Logger.Enums;
using Logger.Layouts;
using Logger.LogFiles;
using System;

namespace Logger.Factories
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel level = ReportLevel.Fatal)
        {
            IAppender appender = type switch
            {
                "ConsoleAppender" => new ConsoleAppender(layout),
                "FileAppender" => new FileAppender(layout, new LogFile()),
                _ => throw new InvalidOperationException()
            };

            appender.ReportLevel = level;
            return appender;
        }
    }
}
