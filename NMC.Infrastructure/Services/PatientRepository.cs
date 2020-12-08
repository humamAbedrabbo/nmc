using Microsoft.EntityFrameworkCore;
using NMC.Core.Services;
using NMC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Infrastructure.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedContext context;

        public PatientRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<Patient> AddPatient(Patient obj)
        {
            obj.Id = 0;
            context.Set<Patient>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await context.Set<Patient>().AsNoTracking().ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await context.Set<Patient>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> GetPatientDetails(int id)
        {
            return await context.Set<Patient>()
                .Include(p => p.Admissions).ThenInclude(p => p.AdmissionType)
                .Include(p => p.Admissions).ThenInclude(p => p.Department)
                .Include(p => p.Appointments).ThenInclude(p => p.AppointmentType)
                .Include(p => p.Appointments).ThenInclude(p => p.Doctor)
                .Include(p => p.Appointments).ThenInclude(p => p.Department)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> UpdatePatient(Patient obj)
        {
            var entry = context.Set<Patient>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
