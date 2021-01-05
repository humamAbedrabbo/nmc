using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Rooms
{
    public class RoomChartModel : PageModel
    {
        private readonly NmcContext context;

        public RoomChartModel(NmcContext context)
        {
            this.context = context;
        }

        public IEnumerable<Room> Rooms { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public async Task OnGetAsync()
        {
            Rooms = await context.Rooms
                .Include(x => x.Slots).ThenInclude(x => x.Booking)
                .Include(x => x.Unit)
                .Include(x => x.CurrentInpatient)
                .OrderBy(x => x.Floor).ThenBy(x => x.RoomNo)
                .ToListAsync();
            Start = DateTime.Today;
            End = Start.AddDays(15);
        }
    }
}
