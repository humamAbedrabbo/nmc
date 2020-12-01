using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Models;
using NMC.Services;

namespace NMC.Pages.EmployeeTypes
{
    public class AddEmployeeTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public AddEmployeeTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public EmployeeType EmployeeType { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await typesRepository.AddEmployeeType(EmployeeType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
