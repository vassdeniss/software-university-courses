using System;
using System.Linq;
using System.Text;

namespace Logger.LogFiles
{
    public class LogFile : ILogFile
    {
        private readonly StringBuilder sb;

        public LogFile() => sb = new StringBuilder();

        public int Size => sb.ToString().Where(char.IsLetter).Sum(x => x);

        public void Write(string message) => sb.Append(message);
    }
}
