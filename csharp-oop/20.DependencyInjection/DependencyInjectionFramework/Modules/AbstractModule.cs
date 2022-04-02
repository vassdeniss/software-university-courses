using System;
using System.Collections.Generic;
using System.Linq;

using DependencyInjectionFramework.Attributes;

namespace DependencyInjectionFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private readonly Dictionary<Type, Dictionary<string, Type>> implementations;
        private readonly Dictionary<Type, object> instances;

        protected AbstractModule()
        {
            implementations = new Dictionary<Type, Dictionary<string, Type>>();
            instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInterface, TImplementation>()
        {
            if (!implementations.ContainsKey(typeof(TInterface)))
            {
                implementations.Add(typeof(TInterface), new Dictionary<string, Type>());
            }

            implementations[typeof(TInterface)].Add(typeof(TImplementation).Name, typeof(TImplementation));
        }

        public object GetInstance(Type type)
        {
            instances.TryGetValue(type, out object value);
            return value;
        }

        public Type GetMapping(Type @interface, object attribute)
        {
            Dictionary<string, Type> curr = implementations[@interface];

            Type type = null;
            if (attribute is Inject)
                return curr.Count == 1
                    ? curr.Values.First()
                    : throw new ArgumentException($"No avalible mapping for class: {@interface.FullName}");
            else if (attribute is Named named)
                return curr[named.Name];

            return type;
        }

        public void SetIntance(Type implementation, object intance)
        {
            if (!instances.ContainsKey(implementation))
            {
                instances.Add(implementation, intance);
            }
        }
    }
}
