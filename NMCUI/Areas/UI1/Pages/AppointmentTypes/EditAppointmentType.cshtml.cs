using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.AppointmentTypes
{
    public class EditAppointmentTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public EditAppointmentTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public AppointmentType AppointmentType { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            AppointmentType = await typesRepository.GetAppointmentType(id);

            if (AppointmentType == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (AppointmentType == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await typesRepository.UpdateAppointmentType(AppointmentType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
