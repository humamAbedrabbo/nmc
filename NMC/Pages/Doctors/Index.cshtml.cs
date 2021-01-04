using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly NmcContext context;

        public IndexModel(NmcContext context)
        {
            this.context = context;
        }

        public IEnumerable<Doctor> Items { get; set; }

        public async Task OnGetAsync()
        {
            Items = await context.Set<Doctor>()
                .Include(x => x.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var entity = await context.Set<Doctor>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                context.Set<Doctor>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Doctors");
        }
    }
}
