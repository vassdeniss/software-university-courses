using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public static class EngineUtils
    {
        private static List<Engine> engines = new List<Engine>();

        public static void AddEngine(Engine engine)
        {
            engines.Add(engine);
        }

        public static Engine GetEngine(string model)
        {
            return engines.FirstOrDefault(x => x.Model == model);
        }
    }
}
