using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Inpatients
{
    public class EditModel : PageModel
    {
        private readonly NmcContext context;

        public EditModel(NmcContext context)
        {
            this.context = context;
        }


        public Inpatient Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        [BindProperty]
        [Display(Name = "Emergency")]
        public bool IsEmergency { get; set; }

        [BindProperty]
        [Display(Name = "Accident")]
        public bool IsAccident { get; set; }

        [BindProperty]
        [StringLength(50)]
        [Display(Name = "Police Ref.")]
        public string PoliceRef { get; set; }

        [BindProperty]
        [Display(Name = "Companion")]
        public bool HasCompanion { get; set; }

        [Display(Name = "Doctor")]
        [BindProperty]
        public int? DoctorId { get; set; }

        public SelectList SelectDoctor { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public async Task InitDataAsync()
        {
            SelectDoctor = new SelectList(
                await context.Doctors
                .Where(x => x.IsReferrer)
                .OrderBy(x => x.FirstName)
                .AsNoTracking()
                .ToListAsync(),
                "Id",
                "Name",
                Entity?.DoctorId
                );

            IsEmergency = Entity.IsEmergency;
            IsAccident = Entity.IsAccident;
            PoliceRef = Entity.PoliceRef;
            HasCompanion = Entity.HasCompanion;
            DoctorId = Entity.DoctorId;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!Id.HasValue) return Redirect("/NotFound");

            Entity = await context.Inpatients
                .Include(x => x.Patient)
                .Include(x => x.CurrentRoom).ThenInclude(x => x.Unit)
                .Include(x => x.Doctor)
                .Where(x => x.Id == Id.Value)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            await InitDataAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Entity = await context.Inpatients
                        .Include(x => x.Patient)
                        .Include(x => x.CurrentRoom).ThenInclude(x => x.Unit)
                        .Include(x => x.Doctor)
                        .Where(x => x.Id == Id.Value)
                        .FirstOrDefaultAsync();

                    if (Entity == null)
                        throw new Exception("Invalid Inpatient");

                    Entity.IsEmergency = IsEmergency;
                    Entity.IsAccident = IsAccident;
                    Entity.PoliceRef = PoliceRef;
                    Entity.HasCompanion = HasCompanion;
                    Entity.Doctor = await context.Doctors.FindAsync(DoctorId);
                    Entity.DoctorId = DoctorId;
                    await context.SaveChangesAsync();
                    return Redirect(ReturnUrl);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }

            await InitDataAsync();
            return Page();
        }
    }
}
