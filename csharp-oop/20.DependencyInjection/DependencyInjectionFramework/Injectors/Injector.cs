using System;
using System.Linq;
using System.Reflection;

using DependencyInjectionFramework.Attributes;
using DependencyInjectionFramework.Modules;

namespace DependencyInjectionFramework.Injectors
{
    public class Injector
    {
        private readonly IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            bool hasCtorAttributes = CheckCtorInjection<TClass>();
            bool hasFieldAttributes = CheckFieldInjection<TClass>();

            if (hasCtorAttributes && hasFieldAttributes)
            {
                throw new ArgumentException("There must be only field or constructor annotated with the inject attribute!");
            }

            if (hasCtorAttributes)
            {
                return CreateCtorInjector<TClass>();
            }

            if (hasFieldAttributes)
            {
                return CreateFieldInjector<TClass>();
            }

            return default;
        }

        private TClass CreateCtorInjector<TClass>()
        {
            Type @class = typeof(TClass);
            if (@class == null) return default;

            ConstructorInfo[] ctors = @class.GetConstructors();
            foreach (ConstructorInfo ctor in ctors)
            {
                if (!CheckCtorInjection<TClass>()) continue;

                Inject inject = (Inject)ctor
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();

                ParameterInfo[] parameterTypes = ctor.GetParameters();

                int idx = 0;
                object[] ctorParams = new object[parameterTypes.Length];
                foreach (ParameterInfo parameter in parameterTypes)
                {
                    Attribute named = parameter.GetCustomAttribute(typeof(Named));

                    Type dependency = null;
                    if (named == null)
                    {
                        dependency = module.GetMapping(parameter.ParameterType, inject);
                    }
                    else
                    {
                        dependency = module.GetMapping(parameter.ParameterType, named);
                    }

                    if (parameter.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            module.SetIntance(parameter.ParameterType, instance);
                        }

                        ctorParams[idx++] = instance;
                    }
                }

                return (TClass)Activator.CreateInstance(@class, ctorParams);
            }

            return default;
        }

        private TClass CreateFieldInjector<TClass>()
        {
            Type @class = typeof(TClass);
            object classInstance = module.GetInstance(@class);
            if (classInstance == null)
            {
                classInstance = Activator.CreateInstance(@class);
                module.SetIntance(@class, classInstance);
            }

            FieldInfo[] fields = @class
                .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                if (!CheckFieldInjection<TClass>()) continue;

                Inject inject = (Inject)field
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();

                Type dependency;
                Attribute named = field.GetCustomAttribute(typeof(Named), true);
                if (named == null)
                {
                    dependency = module.GetMapping(field.FieldType, inject);
                }
                else
                {
                    dependency = module.GetMapping(field.FieldType, named);
                }

                if (field.FieldType.IsAssignableFrom(dependency))
                {
                    object instance = module.GetInstance(dependency);
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance(dependency);
                        module.SetIntance(field.FieldType, instance);
                    }

                    field.SetValue(classInstance, instance);
                }
            }

            return (TClass)classInstance;
        }

        private bool CheckFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Any(x => x.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckCtorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(x => x.GetCustomAttributes(typeof(Inject), true).Any());
        }
    }
}
