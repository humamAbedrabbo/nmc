﻿using NMC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMC.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Department>> GetDepartments();
        Task<Employee> AddEmployee(Employee obj);
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee obj);
    }
}
