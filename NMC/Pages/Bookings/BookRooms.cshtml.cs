using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Bookings
{
    public class BookRoomsModel : PageModel
    {
        private readonly NmcContext context;

        public BookRoomsModel(NmcContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Booking Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start")]
        [BindProperty(SupportsGet = true)]
        public DateTime Start { get; set; } = DateTime.Today.AddDays(1);

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start")]
        [BindProperty(SupportsGet = true)]
        public DateTime End { get; set; } = DateTime.Today.AddDays(2);

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Bookings";

        public IEnumerable<Room> Rooms { get; set; }

        public async Task InitDataAsync()
        {
            Entity = await context.Bookings
                .Include(x => x.Doctor)
                .Include(x => x.Slots).ThenInclude(x => x.Room).ThenInclude(x => x.Unit)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            Rooms = await context.Rooms
                .Include(x => x.Slots).ThenInclude(x => x.Booking)
                .Include(x => x.CurrentInpatient)
                .Include(x => x.Unit)
                .OrderBy(x => x.Floor).ThenBy(x => x.RoomNo)
                .ToListAsync();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
                return Redirect("/NotFound");

            await InitDataAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Start <= DateTime.Now || Start >= DateTime.Today.AddDays(15))
                    ModelState.AddModelError("Start", "Start is out of range");

                if (End <= Start || End >= Start.AddDays(15))
                    ModelState.AddModelError("End", "End is out of range");

            }

            await InitDataAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostBookRoomAsync(int bookingId, int roomId, DateTime date)
        {
            var booking = await context.Bookings
                .Include(x => x.Slots).ThenInclude(x => x.Room)
                .Where(x => x.Id == bookingId)
                .FirstOrDefaultAsync();
            var room = await context.Rooms
                .Include(x => x.Slots).ThenInclude(x => x.Booking)
                .Include(x => x.CurrentInpatient)
                .Where(x => x.Id == roomId)
                .FirstOrDefaultAsync();
            DateTime start = date.Date;
            DateTime end = date.Date.AddDays(1).AddSeconds(-1);
            room.BookSlot(booking, start, end);
            await context.SaveChangesAsync();
            return Redirect($"/Bookings/BookRooms/{bookingId}?start={Start.ToString("yyyy-MM-dd")}&end={End.ToString("yyyy-MM-dd")}");
        }

        public async Task<IActionResult> OnPostDeleteSlotAsync(int id)
        {
            var slot = await context.Set<Timeslot>().FindAsync(id);
            var bookingId = slot.BookingId;
            context.Set<Timeslot>().Remove(slot);
            await context.SaveChangesAsync();
            return Redirect($"/Bookings/BookRooms/{bookingId}?start={Start.ToString("yyyy-MM-dd")}&end={End.ToString("yyyy-MM-dd")}");
        }
    }
}
