using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly NmcContext context;

        public IndexModel(NmcContext context)
        {
            this.context = context;
        }

        public IEnumerable<Patient> Items { get; set; }

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
            Items = await context.Set<Patient>()
                .Where(x =>
                    (string.IsNullOrEmpty(IdentityNo) || EF.Functions.Like(x.IdNo, $"%{IdentityNo}%"))
                    &&
                    (string.IsNullOrEmpty(Name)
                    || EF.Functions.Like(x.FirstName, $"%{Name}%")
                    || EF.Functions.Like(x.LastName, $"%{Name}%")
                    || EF.Functions.Like(x.FatherName, $"%{Name}%")
                    || EF.Functions.Like(x.MotherName, $"%{Name}%")
                    )
                    &&
                    (string.IsNullOrEmpty(Contact)
                    || EF.Functions.Like(x.Phone, $"%{Contact}%")
                    || EF.Functions.Like(x.Mobile, $"%{Contact}%")
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
                var entity = await context.Set<Doctor>().FindAsync(id);
                if (entity == null)
                {
                    return Redirect("/NotFound");
                }

                context.Set<Doctor>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return Redirect("/Patients");
        }
    }
}
