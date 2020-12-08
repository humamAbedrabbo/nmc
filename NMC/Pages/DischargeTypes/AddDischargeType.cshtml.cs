using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMC.Pages.DischargeTypes
{
    public class AddDischargeTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public AddDischargeTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public DischargeType DischargeType { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await typesRepository.AddDischargeType(DischargeType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
