using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMC.Pages.EmployeeTypes
{
    public class EditEmployeeTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public EditEmployeeTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public EmployeeType EmployeeType { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            EmployeeType = await typesRepository.GetEmployeeType(id);

            if (EmployeeType == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (EmployeeType == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await typesRepository.UpdateEmployeeType(EmployeeType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
