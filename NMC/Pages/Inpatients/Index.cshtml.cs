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
    public class IndexModel : PageModel
    {
        private readonly NmcContext context;

        public IndexModel(NmcContext context)
        {
            this.context = context;
        }

        public IEnumerable<Inpatient> Items { get; set; }

        [BindProperty(SupportsGet = true)]
        public string IdentityNo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Contact { get; set; }

        public async Task OnGetAsync()
        {
            await GetDataAsync();
        }

        private async Task GetDataAsync()
        {
            Items = await context.Set<Inpatient>()
                .Include(x => x.Patient)
                .Where(x =>
                    (string.IsNullOrEmpty(IdentityNo) || EF.Functions.Like(x.Patient.IdNo, $"%{IdentityNo}%"))
                    &&
                    (string.IsNullOrEmpty(Name)
                    || EF.Functions.Like(x.Patient.FirstName, $"%{Name}%")
                    || EF.Functions.Like(x.Patient.LastName, $"%{Name}%")
                    || EF.Functions.Like(x.Patient.FatherName, $"%{Name}%")
                    || EF.Functions.Like(x.Patient.MotherName, $"%{Name}%")
                    )
                    &&
                    (string.IsNullOrEmpty(Contact)
                    || EF.Functions.Like(x.Patient.Phone, $"%{Contact}%")
                    || EF.Functions.Like(x.Patient.Mobile, $"%{Contact}%")
                    )
                    )
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task OnPostAsync()
        {
            await GetDataAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var entity = await context.Set<Inpatient>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                context.Set<Inpatient>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Inpatients");
        }
    }
}
