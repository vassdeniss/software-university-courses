using System;

using Formula1.IO.Contracts;

namespace Formula1.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
