using Microsoft.EntityFrameworkCore;
using NMC.Core.Services;
using NMC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Infrastructure.Services
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly MedContext context;

        public AdmissionRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<Admission> AddAdmission(Admission obj)
        {
            obj.Id = 0;
            context.Set<Admission>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Admission>> GetAllAdmissions()
        {
            return await context.Set<Admission>()
                .Include(p => p.ReferrerDoctor)
                .Include(p => p.Patient)
                .Include(p => p.Department)
                .Include(p => p.AdmissionType)
                .Include(p => p.DischargeType)
                .Include(p => p.Reservation)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Admission> GetAdmission(int id)
        {
            return await context.Set<Admission>()
                .Include(p => p.ReferrerDoctor)
                .Include(p => p.Patient)
                .Include(p => p.Department)
                .Include(p => p.AdmissionType)
                .Include(p => p.DischargeType)
                .Include(p => p.Reservation)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Admission> GetAdmissionDetails(int id)
        {
            return await context.Set<Admission>()
                .Include(p => p.ReferrerDoctor)
                .Include(p => p.Patient)
                .Include(p => p.Department)
                .Include(p => p.AdmissionType)
                .Include(p => p.DischargeType)
                .Include(p => p.Reservation)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await context.Set<Doctor>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await context.Set<Department>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await context.Set<Patient>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await context.Set<Reservation>()
                .Include(p => p.Room)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Admission> UpdateAdmission(Admission obj)
        {
            var entry = context.Set<Admission>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
