using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly NmcContext context;

        public CreateModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Patient Entity { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Patients";

        public async Task<IActionResult> OnGetAsync(string idno)
        {
            if (!string.IsNullOrEmpty(idno))
            {
                var patient = await context.Patients
                    .FirstOrDefaultAsync(x => x.IdNo == idno);

                if (patient != null)
                    return Redirect($"/Patients/Edit/{patient.Id}");
            }

            Entity.IdNo = idno;
            return Page();
        }

        public async Task<IActionResult> OnPostFindAsync()
        {
            if (Entity != null && !string.IsNullOrEmpty(Entity.IdNo))
            {
                var patient = await context.Patients
                    .FirstOrDefaultAsync(x => x.IdNo == Entity.IdNo);

                if (patient != null)
                    return Redirect($"/Patients/Edit/{patient.Id}");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string next = null)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Set<Patient>().Add(Entity);
                    await context.SaveChangesAsync();
                    if (next == "inpatient") return Redirect($"/Inpatients/Create/{Entity.Id}");
                    
                    return Redirect(ReturnUrl);

                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }
            return Page();
        }
    }
}
