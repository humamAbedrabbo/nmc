using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<IEnumerable<DoctorSchedule>> GetAllDoctorSchedules();
        Task<Doctor> AddDoctor(Doctor obj);
        Task<DoctorSchedule> AddDoctorSchedule(DoctorSchedule obj);
        Task<Doctor> GetDoctor(int id);
        Task<DoctorSchedule> GetDoctorSchedule(int id);
        Task<Doctor> UpdateDoctor(Doctor obj);
        Task<DoctorSchedule> UpdateDoctorSchedule(DoctorSchedule obj);
    }
}
