using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute { }
}
