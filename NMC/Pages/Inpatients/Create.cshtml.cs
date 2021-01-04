using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Inpatients
{
    public class CreateModel : PageModel
    {
        private readonly NmcContext context;

        public CreateModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Inpatient Entity { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? PatientId { get; set; }


        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Inpatients";

        public async Task OnGetAsync()
        {
            Patient patient;
            if (!PatientId.HasValue)
            {
                patient = new();
                Entity.Patient = patient;
            }
            else
            {
                patient = await context.Patients.FindAsync(PatientId);
                if (patient != null)
                {
                    Entity.PatientId = patient.Id;
                    Entity.Patient = patient;
                }

            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(Entity.Patient != null && Entity.Patient.Id > 0)
                    {
                        context.Entry(Entity.Patient).State = EntityState.Modified;
                    }
                    Entity.CreatedOn = DateTime.Now;
                    Entity.CreatedBy = User.Identity.Name;
                    context.Set<Inpatient>().Add(Entity);
                    await context.SaveChangesAsync();
                    ReturnUrl = $"/Inpatients/Details/{Entity.Id}";
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
