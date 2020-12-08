using Microsoft.EntityFrameworkCore;
using NMC.Core.Services;
using NMC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Infrastructure.Services
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
            context.Set<AdmissionType>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<AppointmentType> AddAppointmentType(AppointmentType obj)
        {
            obj.Id = 0;
            context.Set<AppointmentType>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<DischargeType> AddDischargeType(DischargeType obj)
        {
            obj.Id = 0;
            context.Set<DischargeType>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<EmployeeType> AddEmployeeType(EmployeeType obj)
        {
            obj.Id = 0;
            context.Set<EmployeeType>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<RoomGrade> AddRoomGrade(RoomGrade obj)
        {
            obj.Id = 0;
            context.Set<RoomGrade>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<RoomType> AddRoomType(RoomType obj)
        {
            obj.Id = 0;
            context.Set<RoomType>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<AdmissionType>> GetAllAdmissionTypes()
        {
            return await context.Set<AdmissionType>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AppointmentType>> GetAllAppointmentTypes()
        {
            return await context.Set<AppointmentType>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<DischargeType>> GetAllDischargeTypes()
        {
            return await context.Set<DischargeType>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<EmployeeType>> GetAllEmployeeTypes()
        {
            return await context.Set<EmployeeType>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<RoomGrade>> GetAllRoomGrades()
        {
            return await context.Set<RoomGrade>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await context.Set<RoomType>().AsNoTracking().ToListAsync();
        }

        public async Task<AdmissionType> GetAdmissionType(int id)
        {
            return await context.Set<AdmissionType>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AdmissionType> UpdateAdmissionType(AdmissionType obj)
        {
            var entry = context.Set<AdmissionType>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<AppointmentType> GetAppointmentType(int id)
        {
            return await context.Set<AppointmentType>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AppointmentType> UpdateAppointmentType(AppointmentType obj)
        {
            var entry = context.Set<AppointmentType>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<DischargeType> GetDischargeType(int id)
        {
            return await context.Set<DischargeType>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<DischargeType> UpdateDischargeType(DischargeType obj)
        {
            var entry = context.Set<DischargeType>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<EmployeeType> GetEmployeeType(int id)
        {
            return await context.Set<EmployeeType>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<EmployeeType> UpdateEmployeeType(EmployeeType obj)
        {
            var entry = context.Set<EmployeeType>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<RoomType> GetRoomType(int id)
        {
            return await context.Set<RoomType>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<RoomType> UpdateRoomType(RoomType obj)
        {
            var entry = context.Set<RoomType>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<RoomGrade> GetRoomGrade(int id)
        {
            return await context.Set<RoomGrade>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<RoomGrade> UpdateRoomGrade(RoomGrade obj)
        {
            var entry = context.Set<RoomGrade>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
