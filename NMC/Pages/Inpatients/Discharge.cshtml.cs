using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Inpatients
{
    public class DischargeModel : PageModel
    {
        private readonly NmcContext context;

        public DischargeModel(NmcContext context)
        {
            this.context = context;
        }


        public Inpatient Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Discharge Time")]
        [BindProperty]
        public DateTime DischargeTime { get; set; } = DateTime.Now;

        [BindProperty]
        [Display(Name = "Discharge Type")]
        public DischargeType DischargeType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public async Task InitDataAsync()
        {
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!Id.HasValue) return Redirect("/NotFound");

            Entity = await context.Inpatients
                .Include(x => x.Patient)
                .Include(x => x.CurrentRoom).ThenInclude(x => x.Unit)
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
                        .Where(x => x.Id == Id.Value)
                        .FirstOrDefaultAsync();

                    if (Entity == null)
                        throw new Exception("Invalid Inpatient");

                    if (Entity.GetStatus() == InpatientStatus.Admitted)
                    {
                        Entity.DischargeDate = DischargeTime;
                        Entity.DischargeType = DischargeType;
                        Entity.CurrentRoom = null;
                        Entity.CurrentRoomId = null;
                        await context.SaveChangesAsync();
                    }
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
