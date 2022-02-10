using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Teacher class has a IEnumerable to describe how to iterate over their students
/// id est in reverse order
/// everything else is pretty basic class structure
/// </summary>

namespace VeryDumbProgrammingProblem
{
    public class Teacher : IEnumerable<Student>
    {
        public Teacher(string name, params Student[] students)
        {
            Name = name;
            Students = students.ToList();
        }

        public string Name { get; private set; }
        public List<Student> Students { get; private set; }

        public IEnumerator<Student> GetEnumerator()
        {
            for (int i = Students.Count - 1; i >= 0; i--)
            {
                yield return Students[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            return $"Teacher {Name} teaches:";
        }
    }
}
