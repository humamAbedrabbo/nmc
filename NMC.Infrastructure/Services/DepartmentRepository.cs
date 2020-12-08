using Microsoft.EntityFrameworkCore;
using NMC.Core.Services;
using NMC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Infrastructure.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MedContext context;

        public DepartmentRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<Department> AddDepartment(Department obj)
        {
            //obj.Id = 0;
            context.Set<Department>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await context.Set<Department>().AsNoTracking().ToListAsync();
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await context.Set<Department>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Department> UpdateDepartment(Department obj)
        {
            var entry = context.Set<Department>().Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
