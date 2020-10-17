using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MedContext context;

        public RoomRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<Room> AddRoom(Room obj)
        {
            obj.Id = 0;
            context.Rooms.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await context.Rooms
                .Include(p => p.RoomType)
                .Include(p => p.RoomGrade)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await context.Rooms
                .Include(p => p.RoomType)
                .Include(p => p.RoomGrade)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Room> UpdateRoom(Room obj)
        {
            var entry = context.Rooms.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
