using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMC.Pages.Departments
{
    public class EditDepartmentModel : PageModel
    {
        private readonly IDepartmentRepository departmentRepository;

        public EditDepartmentModel(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Department = await departmentRepository.GetDepartment(id);

            if (Department == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                if(Department == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await departmentRepository.UpdateDepartment(Department);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
