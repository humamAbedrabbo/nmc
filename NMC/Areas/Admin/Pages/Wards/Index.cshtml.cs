using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NMC.Data;
using NMC.Models;

namespace NMC.Areas.Admin.Pages.Wards
{
    public class IndexModel : PageModel
    {
        private readonly MedContext context;

        public IndexModel(MedContext context)
        {
            this.context = context;
        }

        public IEnumerable<Ward> Wards { get; set; }

        public async Task OnGet()
        {
            Wards = await context.Wards.AsNoTracking().ToListAsync();

        }
    }
}
