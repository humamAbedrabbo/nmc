using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly NmcContext context;
        private readonly UserManager<AppUser> userManager;

        public IndexModel(NmcContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IEnumerable<AppUser> Items { get; set; }

        public async Task OnGetAsync()
        {
            Items = await context.Set<AppUser>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            try
            {
                var entity = await context.Set<AppUser>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                context.Set<AppUser>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Users");
        }

        public async Task<IActionResult> OnPostResetPasswordAsync(string id)
        {
            try
            {
                var entity = await context.Set<AppUser>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                var hasher = new PasswordHasher<AppUser>();
                entity.PasswordHash = hasher.HashPassword(entity, "123456");
                context.Set<AppUser>().Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Users");
        }
    }
}
