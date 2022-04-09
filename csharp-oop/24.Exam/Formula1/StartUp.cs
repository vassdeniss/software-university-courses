using Formula1.Core;
using Formula1.Core.Contracts;

namespace Formula1
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
