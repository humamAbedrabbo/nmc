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

namespace NMC.Areas.Admin.Pages.Rooms
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
        public Room Room { get; set; }

        public SelectList RoomGradesSelect { get; set; } 
        public SelectList WardsSelect { get; set; } 

        public async Task OnGet()
        {
            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "ArName" : "EnName";
            RoomGradesSelect = new SelectList(await cacheManager.GetRoomGrades(), "Id", typeNameStr, Room?.RoomGradeId);
            WardsSelect = new SelectList(await cacheManager.GetWards(), "Id", typeNameStr, Room?.WardId);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                context.Rooms.Add(Room);
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
