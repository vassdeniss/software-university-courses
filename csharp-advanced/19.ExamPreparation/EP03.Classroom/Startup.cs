namespace ClassroomProject
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Classroom classroom = new Classroom(10);

            Student student = new Student("Peter", "Parker", "Geometry");
            Student studentTwo = new Student("Sarah", "Smith", "Algebra");
            Student studentThree = new Student("Sam", "Winchester", "Algebra");
            Student studentFour = new Student("Dean", "Winchester", "Music");
            Console.WriteLine(student); 
            
            string register = classroom.RegisterStudent(student);
            string registerTwo = classroom.RegisterStudent(studentTwo);
            string registerThree = classroom.RegisterStudent(studentThree);
            string registerFour = classroom.RegisterStudent(studentFour);
            Console.WriteLine(register);

            string dismissed = classroom.DismissStudent("Peter", "Parker");
            string dismissedTwo = classroom.DismissStudent("Ellie", "Goulding");
            Console.WriteLine(dismissed);
            Console.WriteLine(dismissedTwo);

            string subjectInfo = classroom.GetSubjectInfo("Algebra");
            Console.WriteLine(subjectInfo);

            string anotherInfo = classroom.GetSubjectInfo("Art");
            Console.WriteLine(anotherInfo); 
            
            Console.WriteLine(classroom.GetStudent("Dean", "Winchester"));
        }
    }
}
