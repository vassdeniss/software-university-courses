using System.Collections.Generic;

namespace EXAM01.VaccOps.Models
{
    public class Doctor
    {
        public Doctor(string name, int popularity)
        {
            Name = name;
            Popularity = popularity;
            Patients = new HashSet<Patient>();
        }

        public HashSet<Patient> Patients { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
    }
}
