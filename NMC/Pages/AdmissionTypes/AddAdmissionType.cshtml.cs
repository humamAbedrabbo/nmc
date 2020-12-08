using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMC.Pages.AdmissionTypes
{
    public class AddAdmissionTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public AddAdmissionTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public AdmissionType AdmissionType { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await typesRepository.AddAdmissionType(AdmissionType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
