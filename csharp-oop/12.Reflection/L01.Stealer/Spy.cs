using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classInvestigate, params string[] fieldsInvestigate)
        {
            Type classType = Type.GetType(classInvestigate);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            object instance = Activator.CreateInstance(classType);

            sb.AppendLine($"Class under investigation: {classInvestigate}");
            foreach (FieldInfo field in fields.Where(x => fieldsInvestigate.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().Trim();
        } 
    }
}
