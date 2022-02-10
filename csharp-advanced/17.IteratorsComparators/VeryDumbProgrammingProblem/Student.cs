/// <summary>
/// Just a student class nothing special here
/// </summary>

namespace VeryDumbProgrammingProblem
{
    public class Student
    {
        public Student(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }

        public string Name { get; private set; }
        public int Grade { get; private set; }

        public override string ToString()
        {
            return $" - Student: {Name} / Grade: {Grade}";
        }
    }
}
