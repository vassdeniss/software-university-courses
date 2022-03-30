using System.Threading;

namespace L01.Singleton
{
    internal class Program
    {
        static void Main()
        {
            Thread threadOne = new Thread(() =>
            {
                Singleton.GetInstance();
            });

            Thread threadTwo = new Thread(() =>
            {
                Singleton.GetInstance();
            });

            threadOne.Start();
            threadTwo.Start();
        }
    }
}
