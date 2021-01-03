using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Extensions;
using NMC.Models;

namespace NMC.Pages.Rooms
{
    public class EditModel : PageModel
    {
        private readonly NmcContext context;

        public EditModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Room Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public SelectList SelectUnit { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Rooms";

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
                return Redirect("/NotFound");

            Entity = await context.Rooms.FindAsync(Id);

            if (Entity == null)
                return Redirect("/NotFound");

            await InitSelectLists();
            return Page();
        }

        private async Task InitSelectLists()
        {
            SelectUnit = new SelectList(
                await context.Units.AsNoTracking().ToListAsync(),
                "Id",
                User.IsArabic() ? "NameAr" : "Name",
                Entity?.Id
                );
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Set<Room>().Update(Entity);
                    await context.SaveChangesAsync();
                    return Redirect(ReturnUrl);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }
            await InitSelectLists();
            return Page();
        }
    }
}
