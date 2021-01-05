using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly NmcContext context;

        public IndexModel(NmcContext context)
        {
            this.context = context;
        }

        public IEnumerable<Booking> Items { get; set; }

        public async Task OnGetAsync()
        {
            Items = await context.Set<Booking>()
                .Include(x => x.Doctor)
                .Include(x => x.Reason)
                .Include(x => x.Slots).ThenInclude(x => x.Room).ThenInclude(x => x.Unit)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var entity = await context.Set<Booking>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                context.Set<Booking>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Bookings");
        }

        public async Task<IActionResult> OnPostCancelAsync(int id)
        {
            try
            {
                var entity = await context.Set<Booking>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                var status = entity.GetStatus();
                if(status == BookingStatus.Pending || status == BookingStatus.Expired)
                {
                    entity.CancelledOn = DateTime.Now;
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Bookings");
        }

        public async Task<IActionResult> OnPostConfirmAsync(int id)
        {
            try
            {
                var entity = await context.Set<Booking>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                var status = entity.GetStatus();
                if (status == BookingStatus.Pending || status == BookingStatus.Expired)
                {
                    entity.ConfirmedOn = DateTime.Now;
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Bookings");
        }
    }
}
