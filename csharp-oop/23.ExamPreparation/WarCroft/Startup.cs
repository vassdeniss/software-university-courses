using System;
using WarCroft.Core;
using WarCroft.Core.IO;
using WarCroft.Core.IO.Contracts;

namespace WarCroft
{
	public class StartUp
	{
		public static void Main()
		{
            IReader reader = new ConsoleReader();
            StringBuilderWriter sbWriter = new StringBuilderWriter();

            Engine engine = new Engine(reader, sbWriter);
            engine.Run();

            Console.WriteLine(sbWriter.sb.ToString().Trim());
        }
	}
}
