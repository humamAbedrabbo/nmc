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
    public class EditDischargeTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public EditDischargeTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public DischargeType DischargeType { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            DischargeType = await typesRepository.GetDischargeType(id);

            if (DischargeType == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (DischargeType == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await typesRepository.UpdateDischargeType(DischargeType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
