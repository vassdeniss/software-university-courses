using Logger.Core;

namespace Logger
{
    public class StartUp
    {
        public static void Main()
        {
            IRunnable engine = new Engine();
            engine.Run();
        }
    }
}
