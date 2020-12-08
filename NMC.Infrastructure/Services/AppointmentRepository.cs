using Microsoft.EntityFrameworkCore;
using NMC.Core.Services;
using NMC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Infrastructure.Services
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MedContext context;

        public AppointmentRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<Appointment> AddAppointment(Appointment obj)
        {
            obj.Id = 0;
            context.Set<Appointment>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await context.Set<Appointment>()
                .Include(p => p.AppointmentType)
                .Include(p => p.Patient)
                .Include(p => p.Department)
                .Include(p => p.Doctor)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            return await context.Set<Appointment>()
                .Include(p => p.AppointmentType)
                .Include(p => p.Patient)
                .Include(p => p.Department)
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await context.Set<Department>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await context.Set<Doctor>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await context.Set<Patient>().AsNoTracking().ToListAsync();
        }

        public async Task<Appointment> UpdateAppointment(Appointment obj)
        {
            var entry = context.Set<Appointment>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
