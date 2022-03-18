using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();
            foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("get")))
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("set")))
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");

            return sb.ToString().Trim();
        }
    }
}
