using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
                return Redirect("/NotFound");

            Entity = await userManager.FindByIdAsync(Id);

            if (Entity == null)
                return Redirect("/NotFound");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.FindByIdAsync(Id);
                    user.Email = Entity.Email;
                    user.PhoneNumber = Entity.PhoneNumber;
                    await userManager.UpdateAsync(user);
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
