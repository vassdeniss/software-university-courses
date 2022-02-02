namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name 
        { 
            get { return name; } 
            private set{ name = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }
    }
}
