using EXAM01.VaccOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EXAM01.VaccOps.Core
{
    public class VaccOps
    {
        private readonly Dictionary<string, Doctor> doctors;
        private readonly HashSet<Patient> patients;

        public VaccOps()
        {
            doctors = new Dictionary<string, Doctor>();
            patients = new HashSet<Patient>();
        }

        public void AddDoctor(Doctor d)
        {
            if (doctors.ContainsKey(d.Name)) throw new ArgumentException();
            d.Patients.Clear();
            doctors.Add(d.Name, d);
        }

        public void AddPatient(Doctor d, Patient p)
        {
            if (!doctors.ContainsKey(d.Name) || patients.Contains(p)) throw new ArgumentException();

            doctors[d.Name].Patients.Add(p);
            p.Doctor = doctors[d.Name];
            patients.Add(p);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return doctors.Values;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return patients;
        }

        public bool Exist(Doctor d)
        {
            return doctors.ContainsKey(d.Name);
        }

        public bool Exist(Patient p)
        {
            return patients.Contains(p);
        }

        public Doctor RemoveDoctor(string name)
        {
            if (!doctors.ContainsKey(name)) throw new ArgumentException();

            Doctor doctor = doctors[name];
            foreach (Patient p in doctor.Patients)
            {
                p.Doctor = null;
                patients.Remove(p);
            }

            doctors.Remove(name);
            return doctor;
        }

        public void ChangeDoctor(Doctor from, Doctor to, Patient p)
        {
            if (!doctors.ContainsKey(from.Name) || !doctors.ContainsKey(to.Name) || !patients.Contains(p))
                throw new ArgumentException();

            Patient patient = patients.First(x => x.Equals(p));
            doctors[to.Name].Patients.Add(patient);
            doctors[from.Name].Patients.Remove(patient);
            patient.Doctor = doctors[to.Name];
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            return doctors.Values.Where(x => x.Popularity == populariry);
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            return patients.Where(x => x.Town == town);
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            return patients.Where(x => x.Age <= hi && x.Age >= lo);
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            return doctors.Values.OrderByDescending(x => x.Patients.Count).ThenBy(x => x.Name);
        }

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            return patients.OrderBy(x => x.Doctor.Popularity).ThenByDescending(x => x.Height).ThenBy(x => x.Age).ToList();
        }
    }
}
