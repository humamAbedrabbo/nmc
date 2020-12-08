using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using NMC.Domain.Models;

using NMC.Core.Services;

namespace NMC.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly IDoctorRepository doctorRepository;

        public IndexModel(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> Doctors { get; private set; }

        public async Task OnGet()
        {
            Doctors = await doctorRepository.GetAllDoctors();
        }
    }
}
