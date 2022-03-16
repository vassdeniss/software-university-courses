using Logger.Enums;
using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout) { }

        public override void Append(DateTime time, ReportLevel errorLevel, string message)
        {
            Console.WriteLine(string.Format(Layout.Format, time, errorLevel, message));
            AppendedMessages++;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
