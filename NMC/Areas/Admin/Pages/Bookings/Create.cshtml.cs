using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NMC.Data;
using NMC.Extensions;
using NMC.Models;
using NMC.Services;

namespace NMC.Areas.Admin.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> logger;
        private readonly MedContext context;
        private readonly ICacheManager cacheManager;

        public CreateModel(ILogger<CreateModel> logger, MedContext context, ICacheManager cacheManager)
        {
            this.logger = logger;
            this.context = context;
            this.cacheManager = cacheManager;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public SelectList DoctorsSelect { get; set; } 
        public SelectList WardsSelect { get; set; } 

        public async Task OnGet()
        {
            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "ArName" : "EnName";
            DoctorsSelect = new SelectList(await cacheManager.GetReferrers(), "Id", "Name", Booking?.DoctorId);
            WardsSelect = new SelectList(await cacheManager.GetWards(), "Id", typeNameStr, Booking?.WardId);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var now = DateTime.Now;
                Booking.CreatedOn = now;
                Booking.CreatedBy = User.GetUserName();
                Booking.ValidUntil = now.AddHours(16);
                Booking.Status = BookingStatus.Pending;
                context.Bookings.Add(Booking);
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
