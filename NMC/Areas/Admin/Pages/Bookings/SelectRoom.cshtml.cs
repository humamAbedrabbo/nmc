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
    public class SelectRoomModel : PageModel
    {
        private readonly ILogger<SelectRoomModel> logger;
        private readonly MedContext context;
        private readonly ICacheManager cacheManager;

        public SelectRoomModel(ILogger<SelectRoomModel> logger, MedContext context, ICacheManager cacheManager)
        {
            this.logger = logger;
            this.context = context;
            this.cacheManager = cacheManager;
        }

        
        public Booking Booking { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

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
            WardsSelect = new SelectList(await cacheManager.GetWards(), "Id", typeNameStr, Booking?.WardId);
        }

    }
}
