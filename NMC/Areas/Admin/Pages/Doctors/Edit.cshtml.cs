using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NMC.Data;
using NMC.Models;

namespace NMC.Areas.Admin.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> logger;
        private readonly MedContext context;

        public EditModel(ILogger<EditModel> logger, MedContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task OnGetAsync()
        {
            Doctor = await context.Doctors
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var entry = context.Doctors.Attach(Doctor);
                entry.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
