using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
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
            context.Appointments.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await context.Appointments
                .Include(p => p.AppointmentType)
                .Include(p => p.Patient)
                .Include(p => p.Department)
                .Include(p => p.Doctor)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            return await context.Appointments
                .Include(p => p.AppointmentType)
                .Include(p => p.Patient)
                .Include(p => p.Department)
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await context.Departments.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await context.Doctors.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await context.Patients.AsNoTracking().ToListAsync();
        }

        public async Task<Appointment> UpdateAppointment(Appointment obj)
        {
            var entry = context.Appointments.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
