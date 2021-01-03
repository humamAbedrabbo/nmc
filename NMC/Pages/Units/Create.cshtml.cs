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
    public class CreateModel : PageModel
    {
        private readonly NmcContext context;

        public CreateModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Unit Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Units";

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                try
                {
                    context.Set<Unit>().Add(Entity);
                    await context.SaveChangesAsync();
                    return Redirect(ReturnUrl);
                }
                catch(Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }
            return Page();
        }
    }
}
