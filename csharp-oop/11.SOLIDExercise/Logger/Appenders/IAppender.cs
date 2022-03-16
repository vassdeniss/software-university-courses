using Logger.Enums;
using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        int AppendedMessages { get; }

        void Append(DateTime time, ReportLevel errorLevel, string message);
    }
}
