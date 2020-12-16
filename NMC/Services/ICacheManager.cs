using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface ICacheManager
    {
        Task<IEnumerable<AdmissionType>> GetAdmissionTypes();
        Task<IEnumerable<AppointmentType>> GetAppointmentTypes();
        Task<IEnumerable<Booking>> GetBookings();
        Task<IEnumerable<City>> GetCities();
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<DischargeType>> GetDischargeTypes();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Inpatient>> GetInpatients();
        Task<IEnumerable<Language>> GetLanguages();
        Task<IEnumerable<AppRole>> GetRoles();
        Task<IEnumerable<RoomGrade>> GetRoomGrades();
        Task<IEnumerable<Room>> GetRooms();
        Task<IEnumerable<RoomType>> GetRoomTypes();
        Task<IEnumerable<Speciality>> GetSpecialities();
        Task<IEnumerable<AppUser>> GetUsers();
        Task<IEnumerable<Ward>> GetWards();
        void Reset(string key);
    }
}