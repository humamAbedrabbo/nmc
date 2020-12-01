using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public class TypesRepository : ITypesRepository
    {
        private readonly MedContext context;

        public TypesRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<AdmissionType> AddAdmissionType(AdmissionType obj)
        {
            obj.Id = 0;
            context.AdmissionTypes.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<AppointmentType> AddAppointmentType(AppointmentType obj)
        {
            obj.Id = 0;
            context.AppointmentTypes.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<DischargeType> AddDischargeType(DischargeType obj)
        {
            obj.Id = 0;
            context.DischargeTypes.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<EmployeeType> AddEmployeeType(EmployeeType obj)
        {
            obj.Id = 0;
            context.EmployeeTypes.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<RoomGrade> AddRoomGrade(RoomGrade obj)
        {
            obj.Id = 0;
            context.RoomGrades.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<RoomType> AddRoomType(RoomType obj)
        {
            obj.Id = 0;
            context.RoomTypes.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<AdmissionType>> GetAllAdmissionTypes()
        {
            return await context.AdmissionTypes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AppointmentType>> GetAllAppointmentTypes()
        {
            return await context.AppointmentTypes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<DischargeType>> GetAllDischargeTypes()
        {
            return await context.DischargeTypes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<EmployeeType>> GetAllEmployeeTypes()
        {
            return await context.EmployeeTypes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<RoomGrade>> GetAllRoomGrades()
        {
            return await context.RoomGrades.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await context.RoomTypes.AsNoTracking().ToListAsync();
        }

        public async Task<AdmissionType> GetAdmissionType(int id)
        {
            return await context.AdmissionTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AdmissionType> UpdateAdmissionType(AdmissionType obj)
        {
            var entry = context.AdmissionTypes.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<AppointmentType> GetAppointmentType(int id)
        {
            return await context.AppointmentTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AppointmentType> UpdateAppointmentType(AppointmentType obj)
        {
            var entry = context.AppointmentTypes.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<DischargeType> GetDischargeType(int id)
        {
            return await context.DischargeTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<DischargeType> UpdateDischargeType(DischargeType obj)
        {
            var entry = context.DischargeTypes.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<EmployeeType> GetEmployeeType(int id)
        {
            return await context.EmployeeTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<EmployeeType> UpdateEmployeeType(EmployeeType obj)
        {
            var entry = context.EmployeeTypes.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<RoomType> GetRoomType(int id)
        {
            return await context.RoomTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<RoomType> UpdateRoomType(RoomType obj)
        {
            var entry = context.RoomTypes.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<RoomGrade> GetRoomGrade(int id)
        {
            return await context.RoomGrades.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<RoomGrade> UpdateRoomGrade(RoomGrade obj)
        {
            var entry = context.RoomGrades.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
