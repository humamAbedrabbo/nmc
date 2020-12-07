using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Models;
using NMC.Services;

namespace NMC.Pages.Departments
{
    public class AddDepartmentModel : PageModel
    {
        private readonly IDepartmentRepository departmentRepository;

        public AddDepartmentModel(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Department Department { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await departmentRepository.AddDepartment(Department);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
