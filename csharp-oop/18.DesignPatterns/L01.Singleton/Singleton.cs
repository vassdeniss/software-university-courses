using System;

namespace L01.Singleton
{
    public class Singleton
    {
        private static Singleton instance;
        private static readonly object _lock = new object();

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance is null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                        Console.WriteLine("Created singleton");
                    }
                }
            }

            Console.WriteLine("Returned singleton");
            return instance;
        }
    }
}
