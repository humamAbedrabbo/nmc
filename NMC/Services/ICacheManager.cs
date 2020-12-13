using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface ICacheManager
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<RoomGrade>> GetRoomGrades();
        Task<IEnumerable<Room>> GetRooms();
        Task<IEnumerable<Ward>> GetWards();
        void ResetCache(CacheKeys key);
    }
}