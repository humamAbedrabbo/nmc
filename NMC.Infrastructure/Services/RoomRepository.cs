using Microsoft.EntityFrameworkCore;
using NMC.Core.Services;
using NMC.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Infrastructure.Services
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
            context.Set<Room>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await context.Set<Room>()
                .Include(p => p.RoomType)
                .Include(p => p.RoomGrade)
                .Include(p => p.Ward)
                .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await context.Set<Department>().Where(d => d.DepartmentType == DepartmentType.Ward).AsNoTracking().ToListAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await context.Set<Room>()
                .Include(p => p.RoomType)
                .Include(p => p.RoomGrade)
                .Include(p => p.Ward)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Room> UpdateRoom(Room obj)
        {
            var entry = context.Set<Room>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
