using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly IPatientRepository patientRepository;

        public DetailsModel(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Patient = await patientRepository.GetPatientDetails(id);

            if (Patient == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
