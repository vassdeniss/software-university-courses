using Gym.Core;
using Gym.Core.Contracts;

namespace Gym
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
