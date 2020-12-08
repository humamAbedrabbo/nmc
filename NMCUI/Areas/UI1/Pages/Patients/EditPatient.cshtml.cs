using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.Patients
{
    public class EditPatientModel : PageModel
    {
        private readonly IPatientRepository patientRepository;

        public EditPatientModel(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Patient = await patientRepository.GetPatient(id);

            if (Patient == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Patient == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await patientRepository.UpdatePatient(Patient);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
