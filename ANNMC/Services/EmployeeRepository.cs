using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MedContext context;

        public EmployeeRepository(MedContext context)
        {
            this.context = context;
        }

        public async Task<Employee> AddEmployee(Employee obj)
        {
            obj.Id = 0;
            context.Employees.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await context.Employees
                .Include(x => x.Department)
                .Include(x => x.EmployeeType)   
                .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await context.Departments.AsNoTracking().ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await context.Employees
                .Include(x => x.Department)
                .Include(x => x.EmployeeType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Employee> UpdateEmployee(Employee obj)
        {
            var entry = context.Employees.Attach(obj);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
