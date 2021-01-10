using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMC.Data;
using NMC.Models;
using NMC.Services;

namespace NMC.Pages.Inpatients
{
    public class CreateModel : PageModel
    {
        private readonly NmcContext context;
        private readonly IBarcodeGen barcodeGen;

        public CreateModel(NmcContext context, IBarcodeGen barcodeGen)
        {
            this.context = context;
            this.barcodeGen = barcodeGen;
        }

        [BindProperty]
        public Inpatient Entity { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? PatientId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } = "/Inpatients";

        [BindProperty(SupportsGet = true)]
        public int? BookingId { get; set; }

        public SelectList SelectBooking { get; set; }
        public SelectList SelectDoctor { get; set; }

        public async Task InitDataAsync()
        {
            var bookings = await context.Bookings
                .Include(x => x.Doctor)
                .Where(x => !x.CancelledOn.HasValue && !x.ClosedOn.HasValue)
                .OrderBy(x => x.PatientFirstName)
                .ToListAsync();
                
            SelectBooking = new SelectList(
                bookings,
                "Id",
                "Name",
                Entity?.BookingId
                );

            SelectDoctor = new SelectList(
                await context.Doctors
                    .Where(x => x.IsReferrer)
                    .OrderBy(x => x.FirstName)
                    .ToListAsync(),
                "Id",
                "Name"

                );
        }

        public async Task OnGetAsync()
        {
            Patient patient;
            if (!PatientId.HasValue)
            {
                patient = new();
                Entity.Patient = patient;
            }
            else
            {
                patient = await context.Patients.FindAsync(PatientId);
                if (patient != null)
                {
                    Entity.PatientId = patient.Id;
                    Entity.Patient = patient;
                }

            }
            Entity.BookingId = BookingId;
            if (BookingId.HasValue)
            {
                // Set Default Est Dur from Booking Info
                var booking = await context.Bookings
                    .Include(x => x.Slots)
                    .Where(x => x.Id == BookingId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                var minStart = booking.Slots.Min(x => x.StartDate);
                var maxEnd = booking.Slots.Max(x => x.End);
                Entity.EstDays = (maxEnd - minStart).Days;
                if (Entity.EstDays < 1) Entity.EstDays = 1;

                // Set Doctor referral from Booking
                Entity.DoctorId = booking.DoctorId;
                if (string.IsNullOrEmpty(Entity.Patient?.FirstName) && string.IsNullOrEmpty(Entity.Patient?.LastName))
                {
                    Entity.Patient.FirstName = booking.PatientFirstName;
                    Entity.Patient.LastName = booking.PatientLastName;
                    Entity.Patient.Gender = booking.Gender;
                }
                await InitDataAsync();
            }
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(Entity.Patient != null && Entity.Patient.Id > 0)
                    {
                        context.Entry(Entity.Patient).State = EntityState.Modified;
                    }
                    Entity.CreatedOn = DateTime.Now;
                    Entity.CreatedBy = User.Identity.Name;
                    //TODO: Add Booking Details
                    if (Entity.BookingId.HasValue)
                    {
                        var booking = await context.Bookings
                            .Where(x => x.Id == Entity.BookingId)
                            .FirstOrDefaultAsync();

                        booking.Inpatient = Entity;
                        if (!booking.ConfirmedOn.HasValue) booking.ConfirmedOn = DateTime.Now;

                        // Get Requirements
                    }

                    context.Set<Inpatient>().Add(Entity);
                    await context.SaveChangesAsync();
                    ReturnUrl = $"/Inpatients/Details/{Entity.Id}";

                    // Generate Barcode
                    barcodeGen.Generate(Entity.Id);

                    return Redirect(ReturnUrl);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message + ",, " + ex.InnerException?.Message;
                }
            }

            await InitDataAsync();
            return Page();
        }
    }
}
