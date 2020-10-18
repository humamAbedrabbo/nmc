using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> AddPatient(Patient obj);
        Task<Patient> GetPatient(int id);
        Task<Patient> GetPatientDetails(int id);
        Task<Patient> UpdatePatient(Patient obj);
    }
}
