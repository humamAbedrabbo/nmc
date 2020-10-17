using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
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
            context.Patients.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await context.Patients.AsNoTracking().ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> UpdatePatient(Patient obj)
        {
            var entry = context.Patients.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
