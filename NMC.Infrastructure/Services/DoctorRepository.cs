using Microsoft.EntityFrameworkCore;
using NMC.Core.Services;
using NMC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Infrastructure.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MedContext context;

        public DoctorRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<Doctor> AddDoctor(Doctor obj)
        {
            obj.Id = 0;
            context.Set<Doctor>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<DoctorSchedule> AddDoctorSchedule(DoctorSchedule obj)
        {
            obj.Id = 0;
            context.Set<DoctorSchedule>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await context.Set<Doctor>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<DoctorSchedule>> GetAllDoctorSchedules()
        {
            return await context.Set<DoctorSchedule>()
                .Include(p => p.Doctor)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await context.Set<Doctor>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Doctor> GetDoctorDetails(int id)
        {
            return await context.Set<Doctor>()
                .Include(p => p.DepartmentDoctors).ThenInclude(p => p.Department)
                .Include(p => p.ExperienceDetails)
                .Include(p => p.EducationDetails)
                .Include(p => p.Schedules)
                .Include(p => p.Appointments).ThenInclude(p => p.Department)
                .Include(p => p.Appointments).ThenInclude(p => p.Patient)
                .Include(p => p.Appointments).ThenInclude(p => p.AppointmentType)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<DoctorSchedule> GetDoctorSchedule(int id)
        {
            return await context.Set<DoctorSchedule>()
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Doctor> UpdateDoctor(Doctor obj)
        {
            var entry = context.Set<Doctor>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<DoctorSchedule> UpdateDoctorSchedule(DoctorSchedule obj)
        {
            var entry = context.Set<DoctorSchedule>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }


    }
}
