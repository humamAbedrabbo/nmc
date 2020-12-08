using Microsoft.EntityFrameworkCore;
using NMC.Core.Services;
using NMC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Infrastructure.Services
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MedContext context;

        public ReservationRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<Reservation> AddReservation(Reservation obj)
        {
            obj.Id = 0;
            context.Set<Reservation>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await context.Set<Reservation>()
                .Include(p => p.Room)
                .Include(p => p.Patient)
                .Include(p => p.Grade)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Reservation> GetReservation(int id)
        {
            return await context.Set<Reservation>()
                .Include(p => p.Room)
                .Include(p => p.Patient)
                .Include(p => p.Grade)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await context.Set<Room>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<RoomGrade>> GetGrades()
        {
            return await context.Set<RoomGrade>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await context.Set<Patient>().AsNoTracking().ToListAsync();
        }

        public async Task<Reservation> UpdateReservation(Reservation obj)
        {
            var entry = context.Set<Reservation>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
