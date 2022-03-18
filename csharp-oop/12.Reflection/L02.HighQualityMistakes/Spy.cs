using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo field in fields)
                sb.AppendLine($"{field.Name} must be private!");
            foreach (MethodInfo publicMethod in publicMethods.Where(x => x.Name.StartsWith("set")))
                sb.AppendLine($"{publicMethod.Name} have to be private!"); // has*
            foreach (MethodInfo nonPublicMethod in publicMethods.Where(x => x.Name.StartsWith("get")))
                sb.AppendLine($"{nonPublicMethod.Name} have to be private!"); // has*

            return sb.ToString().Trim();
        }
    }
}
