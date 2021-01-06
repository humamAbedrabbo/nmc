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
    public class EditModel : PageModel
    {
        private readonly NmcContext context;
        private readonly UserManager<AppUser> userManager;

        public EditModel(NmcContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [BindProperty]
        public AppUser Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Users";

        public string[] AppRoles => AppRole.GetRoles();

        public List<string> SelectedRoles { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
                return Redirect("/NotFound");

            Entity = await context.Users
                .Include(x => x.Doctor)
                .Where(x => x.Id == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (Entity == null)
                return Redirect("/NotFound");

            SelectedRoles = (await userManager.GetRolesAsync(Entity)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string[] roles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.FindByIdAsync(Id);
                    user.Email = Entity.Email;
                    user.PhoneNumber = Entity.PhoneNumber;
                    await userManager.UpdateAsync(user);

                    SelectedRoles = (await userManager.GetRolesAsync(Entity)).ToList();
                    if(roles != null)
                    {
                        var rolesToRemove = SelectedRoles.Where(x => !roles.Contains(x));
                        var rolesToAdd = roles.Where(x => !SelectedRoles.Contains(x));

                        await userManager.RemoveFromRolesAsync(user, rolesToRemove);
                        await userManager.AddToRolesAsync(user, rolesToAdd);
                    }
                    else if(SelectedRoles.Count > 0)
                    {
                        await userManager.RemoveFromRolesAsync(user, SelectedRoles);
                    }

                    return Redirect(ReturnUrl);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }
            return Page();
        }
    }
}
