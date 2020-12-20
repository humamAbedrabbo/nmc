using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface ICacheManager
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Inpatient>> GetInpatients();
        Task<IEnumerable<AppRole>> GetRoles();
        Task<IEnumerable<Room>> GetRooms();
        Task<IEnumerable<Speciality>> GetSpecialities();
        Task<IEnumerable<Ward>> GetWards();
        void Reset(string key);
    }
}