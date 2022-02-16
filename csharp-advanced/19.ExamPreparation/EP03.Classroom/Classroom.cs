namespace ClassroomProject
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Classroom
    {
        public Classroom(int capacity)
        {
            Students = new List<Student>();
            Capacity = capacity;
        }

        public List<Student> Students { get; private set; }
        public int Capacity { get; private set; }
        public int Count => Students.Count;

        public string RegisterStudent(Student student)
        {
            if (Students.Count == Capacity)
            {
                return "No seats in the classroom"; 
            }

            Students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = Students
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student == null)
            {
                return "Student not found";
            }

            Students.Remove(student);
            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> matchingStudents = Students.Where(x => x.Subject == subject).ToList();
            if (matchingStudents.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            matchingStudents.ForEach(x => sb.AppendLine($"{x.FirstName} {x.LastName}"));

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return Students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
