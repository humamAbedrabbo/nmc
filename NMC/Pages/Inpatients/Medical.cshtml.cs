using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Inpatients
{
    public class MedicalModel : PageModel
    {
        private readonly NmcContext context;

        public MedicalModel(NmcContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Inpatient Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (!Id.HasValue) return Redirect("/NotFound");

            Entity = await context.Inpatients
                .Include(x => x.Patient)
                .Include(x => x.CurrentRoom).ThenInclude(x => x.Unit)
                .Include(x => x.Doctor)
                .Where(x => x.Id == Id.Value)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return Page();
        }
    }
}
