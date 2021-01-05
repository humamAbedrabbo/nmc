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

namespace NMC.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly NmcContext context;

        public EditModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Booking Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public SelectList SelectReason { get; set; }
        public SelectList SelectDoctor { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Bookings";

        public async Task InitDataAsync()
        {
            SelectReason = new SelectList(
                await context.BookingReasonTypes.ToListAsync(),
                "Id",
                User.IsArabic() ? "NameAr" : "Name",
                Entity?.ReasonId
                );

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
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
                return Redirect("/NotFound");

            Entity = await context.Bookings
                .Include(x => x.Doctor)
                .Include(x => x.Reason)
                .Include(x => x.Slots).ThenInclude(x => x.Room).ThenInclude(x => x.Unit)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            if (Entity == null)
                return Redirect("/NotFound");

            await InitDataAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string rooms = null)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Set<Booking>().Update(Entity);
                    await context.SaveChangesAsync();
                    if (!string.IsNullOrEmpty(rooms)) return Redirect($"/Bookings/BookRooms/{Entity.Id}");
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
