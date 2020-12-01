using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
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
            context.Admissions.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Admission>> GetAllAdmissions()
        {
            return await context.Admissions
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
            return await context.Admissions
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
            return await context.Admissions
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
            return await context.Doctors.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await context.Departments.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await context.Patients.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await context.Reservations
                .Include(p => p.Room)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Admission> UpdateAdmission(Admission obj)
        {
            var entry = context.Admissions.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
