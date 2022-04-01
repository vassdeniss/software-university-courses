    using System.Collections.Generic;

namespace E01.Prototype
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches 
            = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get => sandwiches[name];
            set => sandwiches.Add(name, value);
        }
    }
}
