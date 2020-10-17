using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
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
            context.Reservations.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await context.Reservations
                .Include(p => p.Room)
                .Include(p => p.Patient)
                .Include(p => p.Grade)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Reservation> GetReservation(int id)
        {
            return await context.Reservations
                .Include(p => p.Room)
                .Include(p => p.Patient)
                .Include(p => p.Grade)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await context.Rooms.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<RoomGrade>> GetGrades()
        {
            return await context.RoomGrades.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await context.Patients.AsNoTracking().ToListAsync();
        }

        public async Task<Reservation> UpdateReservation(Reservation obj)
        {
            var entry = context.Reservations.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
