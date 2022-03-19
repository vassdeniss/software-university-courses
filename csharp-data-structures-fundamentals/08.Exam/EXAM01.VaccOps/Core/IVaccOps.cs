using EXAM01.VaccOps.Models;
using System.Collections.Generic;

namespace EXAM01.VaccOps.Core
{
    public interface IVaccOps
    {
        void AddDoctor(Doctor d);
        
        void AddPatient(Doctor d, Patient p);

        IEnumerable<Doctor> GetDoctors();

        IEnumerable<Patient> GetPatients();

        bool Exist(Doctor d);

        bool Exist(Patient p);

        Doctor RemoveDoctor(string name);

        void ChangeDoctor(Doctor from, Doctor to, Patient p);

        IEnumerable<Doctor> GetDoctorsByPopularity(int populariry);

        IEnumerable<Patient> GetPatientsByTown(string town);

        IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi);

        IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc();

        IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge();
    }
}
