using Logger.Enums;
using Logger.Layouts;
using Logger.LogFiles;
using System;
using System.IO;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile file;

        public FileAppender(ILayout layout, ILogFile file) : base(layout)
        {
            this.file = file;
        }

        public override void Append(DateTime time, ReportLevel errorLevel, string message)
        {
            string path = "../../../log.txt";
            string output = string.Format(Layout.Format, time, errorLevel, message);

            file.Write(output);

            File.AppendAllText(path, output);

            AppendedMessages++;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {file.Size}";
        }
    }
}
