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

namespace NMC.Pages.Patients
{
    public class AddPatientModel : PageModel
    {
        private readonly IPatientRepository patientRepository;

        public AddPatientModel(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Patient Patient { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Patient = await patientRepository.AddPatient(Patient);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
