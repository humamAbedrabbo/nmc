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

namespace NMC.Areas.Admin.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly MedContext context;

        public IndexModel(MedContext context)
        {
            this.context = context;
        }

        public IEnumerable<Room> Rooms { get; set; }

        public async Task OnGet()
        {
            Rooms = await context.Rooms
                .Include(x => x.Ward)
                .Include(x => x.RoomGrade)
                .AsNoTracking().ToListAsync();

        }
    }
}
