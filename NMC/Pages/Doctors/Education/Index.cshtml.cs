using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Doctors.Education
{
    public class IndexModel : PageModel
    {
        private readonly NmcContext contetxt;

        public IndexModel(NmcContext contetxt)
        {
            this.contetxt = contetxt;
        }

        public IEnumerable<DoctorEducation> Items { get; set; }
        
        [BindProperty(SupportsGet = true)] 
        public int DoctorId { get; set; }

        public async Task OnGetAsync()
        {

            Items = await contetxt.DoctorEducations
                .Include(x => x.Doctor)
                .Where(x => x.DoctorId == DoctorId)
                .OrderByDescending(x => x.StartingYear)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

