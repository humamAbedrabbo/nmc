using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.Admissions
{
    public class DetailsModel : PageModel
    {
        private readonly IAdmissionRepository admRepository;

        public DetailsModel(IAdmissionRepository admRepository)
        {
            this.admRepository = admRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Admission Admission { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Admission = await admRepository.GetAdmissionDetails(id);

            if (Admission == null)
                return RedirectToPage("/MotFound");

            return Page();
        }
    }
}
