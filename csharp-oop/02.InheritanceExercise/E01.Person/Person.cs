namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name => name;
        public int Age => age;

        public override string ToString()
        {
            return $"Name: {name}, Age: {age}"; 
        }
    }
}
