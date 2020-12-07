using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IAdmissionRepository
    {
        Task<IEnumerable<Admission>> GetAllAdmissions();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Department>> GetDepartments();
        Task<IEnumerable<Reservation>> GetReservations();
        Task<Admission> AddAdmission(Admission obj);
        Task<Admission> GetAdmission(int id);
        Task<Admission> GetAdmissionDetails(int id);
        Task<Admission> UpdateAdmission(Admission obj);
    }
}
