using System.Text;

using WarCroft.Core.IO.Contracts;

namespace WarCroft.Core.IO
{
    public class StringBuilderWriter : IWriter
    {
        public StringBuilder sb = new StringBuilder();

        public void WriteLine(string message)
        {
            sb.AppendLine(message);
        }
    }
}
