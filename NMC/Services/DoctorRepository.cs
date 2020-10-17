﻿using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
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
            context.Doctors.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await context.Doctors.AsNoTracking().ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await context.Doctors.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Doctor> UpdateDoctor(Doctor obj)
        {
            var entry = context.Doctors.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
