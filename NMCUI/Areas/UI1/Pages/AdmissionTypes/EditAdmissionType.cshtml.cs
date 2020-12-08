using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.AdmissionTypes
{
    public class EditAdmissionTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public EditAdmissionTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public AdmissionType AdmissionType { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            AdmissionType = await typesRepository.GetAdmissionType(id);

            if (AdmissionType == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (AdmissionType == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await typesRepository.UpdateAdmissionType(AdmissionType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
