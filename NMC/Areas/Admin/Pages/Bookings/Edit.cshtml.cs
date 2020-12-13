using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NMC.Data;
using NMC.Extensions;
using NMC.Models;
using NMC.Services;

namespace NMC.Areas.Admin.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> logger;
        private readonly MedContext context;
        private readonly ICacheManager cacheManager;

        public EditModel(ILogger<EditModel> logger, MedContext context, ICacheManager cacheManager)
        {
            this.logger = logger;
            this.context = context;
            this.cacheManager = cacheManager;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public SelectList DoctorsSelect { get; set; }

        public SelectList WardsSelect { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task OnGetAsync()
        {
            Booking = await context.Bookings
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "ArName" : "EnName";
            DoctorsSelect = new SelectList(await cacheManager.GetReferrers(), "Id", "Name", Booking?.DoctorId);
            WardsSelect = new SelectList(await cacheManager.GetWards(), "Id", typeNameStr, Booking?.WardId);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var entry = context.Bookings.Attach(Booking);
                entry.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
