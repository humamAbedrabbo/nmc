using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Units
{
    public class EditModel : PageModel
    {
        private readonly NmcContext context;

        public EditModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Unit Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Units";

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
                return Redirect("/NotFound");

            Entity = await context.Units.FindAsync(Id);

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
                    context.Set<Unit>().Update(Entity);
                    await context.SaveChangesAsync();
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
