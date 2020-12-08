using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly IDoctorRepository doctorRepository;

        public DetailsModel(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public Doctor Doctor { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Doctor = await doctorRepository.GetDoctorDetails(id);

            if (Doctor == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
