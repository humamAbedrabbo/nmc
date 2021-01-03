using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly NmcContext context;

        public IndexModel(NmcContext context)
        {
            this.context = context;
        }

        public IEnumerable<Room> Items { get; set; }

        public async Task OnGetAsync()
        {
            Items = await context.Set<Room>()
                .Include(x => x.Unit)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var entity = await context.Set<Room>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                context.Set<Room>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Rooms");
        }
    }
}
