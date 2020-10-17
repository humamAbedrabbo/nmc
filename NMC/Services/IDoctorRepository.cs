using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<Doctor> AddDoctor(Doctor obj);
        Task<Doctor> GetDoctor(int id);
        Task<Doctor> UpdateDoctor(Doctor obj);
    }
}
