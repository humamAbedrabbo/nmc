using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly NmcContext context;

        public CreateModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Doctor Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Doctors";

        public MultiSelectList SpecSelect { get; set; }

        [BindProperty] public List<int> Specs { get; set; } = new();

        public async Task InitDataAsync()
        {
            SpecSelect = new MultiSelectList(await context.Specialities.OrderBy(x => x.Name).ToListAsync(), "Id", "Name", Specs);
        }

        public async Task OnGetAsync()
        {
            await InitDataAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Entity.Specialities = await context.Specialities
                    .Where(x => Specs.Contains(x.Id)).ToListAsync();

                    context.Set<Doctor>().Add(Entity);
                    await context.SaveChangesAsync();
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
