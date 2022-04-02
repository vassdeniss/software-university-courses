using System;

namespace DependencyInjectionFramework.Modules
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type @interface, object attribute);

        object GetInstance(Type type);

        void SetIntance(Type implementation, object intance);
    }
}
