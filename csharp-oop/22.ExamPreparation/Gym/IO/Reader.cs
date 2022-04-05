using System;

using Gym.IO.Contracts;

namespace Gym.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
