using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MedContext context;

        public DepartmentRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await context.Departments.AsNoTracking().ToListAsync();
        }
    }
}
