using NMC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Core.Services
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<IEnumerable<Department>> GetDepartments();
        Task<Room> AddRoom(Room obj);
        Task<Room> GetRoom(int id);
        Task<Room> UpdateRoom(Room obj);
    }
}
