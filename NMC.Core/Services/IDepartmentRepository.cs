using NMC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Core.Services
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> AddDepartment(Department obj);
        Task<Department> GetDepartment(int id);
        Task<Department> UpdateDepartment(Department obj);
    }
}
