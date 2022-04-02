using DependencyInjectionFramework.Modules;

namespace DependencyInjectionFramework.Injectors
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
