using Logger.Appenders;
using Logger.Enums;
using System;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appender) => Appenders = appender;

        public IAppender[] Appenders { get; }

        public void Error(string message) => Log(ReportLevel.Error, message);

        public void Info(string message) => Log(ReportLevel.Info, message);

        public void Warn(string message) => Log(ReportLevel.Warning, message);

        public void Fatal(string message) => Log(ReportLevel.Fatal, message);

        public void Critical(string message) => Log(ReportLevel.Critical, message);

        private void Log(ReportLevel level, string message)
        {
            foreach (IAppender appender in Appenders)
            {
                if (level >= appender.ReportLevel)
                {
                    appender.Append(DateTime.Now, level, message);
                }
            }
        }
    }
}
