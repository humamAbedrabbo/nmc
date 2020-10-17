using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> AddRoom(Room obj);
        Task<Room> GetRoom(int id);
        Task<Room> UpdateRoom(Room obj);
    }
}
