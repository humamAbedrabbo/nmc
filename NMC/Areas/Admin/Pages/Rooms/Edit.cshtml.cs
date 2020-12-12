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

namespace NMC.Areas.Admin.Pages.Rooms
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
        public Room Room { get; set; }

        public SelectList RoomGradesSelect { get; set; }

        public SelectList WardsSelect { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task OnGetAsync()
        {
            Room = await context.Rooms
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "ArName" : "EnName";
            RoomGradesSelect = new SelectList(await cacheManager.GetRoomGrades(), "Id", typeNameStr, Room?.RoomGradeId);
            WardsSelect = new SelectList(await cacheManager.GetWards(), "Id", typeNameStr, Room?.WardId);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var entry = context.Rooms.Attach(Room);
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
