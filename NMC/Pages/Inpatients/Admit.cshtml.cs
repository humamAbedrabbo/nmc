using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;

namespace NMC.Pages.Inpatients
{
    public class AdmitModel : PageModel
    {
        private readonly NmcContext context;

        public AdmitModel(NmcContext context)
        {
            this.context = context;
        }


        public Inpatient Entity { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Admission Time")]
        [BindProperty]
        public DateTime AdmissionTime { get; set; } = DateTime.Now;

        [Display(Name = "Est. Days")]
        [Range(1, 15)]
        [BindProperty]
        public int EstDays { get; set; } = 1;

        [BindProperty]
        [Display(Name = "Room")]
        public int RoomId { get; set; }

        [BindProperty]
        [Display(Name = "Emergency")]
        public bool IsEmergency { get; set; }

        [BindProperty]
        [Display(Name = "Accident")]
        public bool IsAccident { get; set; }

        [BindProperty]
        [StringLength(50)]
        [Display(Name = "Police Ref.")]
        public string PoliceRef { get; set; }

        [BindProperty]
        [Display(Name = "Companion")]
        public bool HasCompanion { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public async Task InitDataAsync()
        {
            Rooms = (await context.Rooms
                    .Include(x => x.Unit)
                    .Include(x => x.Slots).ThenInclude(x => x.Booking)
                    .Include(x => x.CurrentInpatient).ThenInclude(x => x.Patient)
                    .Where(x => x.Unit.Type == UnitType.IPD)
                    .OrderBy(x => x.Floor).ThenBy(x => x.RoomNo)
                    .ToListAsync());

            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!Id.HasValue) return Redirect("/NotFound");

            Entity = await context.Inpatients
                .Include(x => x.Patient)
                .Include(x => x.CurrentRoom).ThenInclude(x => x.Unit)
                .Where(x => x.Id == Id.Value)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            await InitDataAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Entity = await context.Inpatients.FindAsync(Id);
                    if (Entity == null)
                        throw new Exception("Invalid Inpatient");

                    if(Entity.GetStatus() == InpatientStatus.Pending)
                    {
                        Entity.AdmissionDate = AdmissionTime;
                        Entity.EstDays = EstDays;
                        var room = await context.Rooms
                            .Include(x => x.Slots).ThenInclude(x => x.Booking)
                            .Include(x => x.CurrentInpatient)
                            .Where(x => x.Id == RoomId)
                            .FirstOrDefaultAsync();
                        //if(!room.IsAvailable(Entity.AdmissionDate.Value, Entity.EstDischargeDate.Value))
                        //{
                        //    throw new Exception($"Room {room.Name} is not available");
                        //}
                        Entity.CurrentRoom = room;
                        Entity.CurrentRoomId = RoomId;


                        Entity.IsAccident = IsAccident;
                        Entity.IsEmergency = IsEmergency;
                        Entity.PoliceRef = PoliceRef;
                        Entity.HasCompanion = HasCompanion;
                        await context.SaveChangesAsync();
                        //TODO: Booking to inpatient
                        //if (Entity.BookingId.HasValue)
                        //{
                        //    var booking = await context.Bookings
                        //        .Include(x => x.Slots).ThenInclude(x => x.Room).ThenInclude(x => x.Unit)
                        //        .Where(x => x.Id == Entity.BookingId)
                        //        .FirstOrDefaultAsync();
                        //    var admittionRoom = booking.Slots.OrderBy(x => x.StartDate)
                        //        .Where(x => x.Room.Unit.Type == UnitType.IPD)
                        //        .Select(x => x.Room).FirstOrDefault();
                        //    if (admittionRoom != null)
                        //    {
                        //        Entity.CurrentRoom = admittionRoom;
                        //        Entity.CurrentRoomId = admittionRoom.Id;
                        //        await context.SaveChangesAsync();
                        //    }
                        //}
                    }
                    return Redirect(ReturnUrl);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }

            await InitDataAsync();
            return Page();
        }
    }
}
