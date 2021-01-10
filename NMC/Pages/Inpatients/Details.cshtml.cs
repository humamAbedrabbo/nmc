using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using NMC.Services;

namespace NMC.Pages.Inpatients
{
    public class DetailsModel : PageModel
    {
        private readonly NmcContext context;
        private readonly IBarcodeGen barcodeGen;

        public DetailsModel(NmcContext context, IBarcodeGen barcodeGen)
        {
            this.context = context;
            this.barcodeGen = barcodeGen;
        }

        public Inpatient Entity { get; set; }

        public string Barcode { get; set; }

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
            Barcode = barcodeGen.Generate(Entity.Id, Entity.CurrentRoom?.Name ?? "");
            return Page();
        }
    }
}
