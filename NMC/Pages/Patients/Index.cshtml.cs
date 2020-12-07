using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using NMC.Models;

using NMC.Services;

namespace NMC.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly IPatientRepository patientRepository;

        public IndexModel(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public IEnumerable<Patient> Patients { get; private set; }

        public async Task OnGet()
        {
            Patients = await patientRepository.GetAllPatients();
        }
    }
}
