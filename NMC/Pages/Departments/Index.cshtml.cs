using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using NMC.Models;

using NMC.Services;

namespace NMC.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentRepository departmentRepository;

        public IndexModel(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> Departments { get; private set; }

        public async Task OnGet()
        {
            Departments = await departmentRepository.GetAllDepartments();
        }
    }
}
