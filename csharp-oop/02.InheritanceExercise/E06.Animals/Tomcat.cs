using System;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TOMCAT_GENDER = "Male";

        public Tomcat(string name, int age) 
            : base(name, age, TOMCAT_GENDER) { }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
