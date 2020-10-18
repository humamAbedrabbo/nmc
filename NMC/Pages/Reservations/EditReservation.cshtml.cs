using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMC.Extensions;
using NMC.Models;
using NMC.Services;

namespace NMC.Pages.Reservations
{
    public class EditReservationModel : PageModel
    {
        private readonly IReservationRepository rsvRepository;
        private readonly ITypesRepository typesRepository;

        public EditReservationModel(IReservationRepository rsvRepository, ITypesRepository typesRepository)
        {
            this.rsvRepository = rsvRepository;
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Reservation Reservation { get; set; }

        public SelectList RoomsSelect { get; set; }
        public SelectList GradesSelect { get; set; }
        public SelectList PatientsSelect { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Reservation = await rsvRepository.GetReservation(id);

            if (Reservation == null)
            {
                return RedirectToPage("/NotFound");
            }

            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "NameAr" : "Name";
            RoomsSelect = new SelectList(await rsvRepository.GetRooms(), "Id", "RoomNo", Reservation?.RoomNo);
            PatientsSelect = new SelectList(await rsvRepository.GetPatients(), "Id", "Name", Reservation?.PatientId);
            GradesSelect = new SelectList(await rsvRepository.GetGrades(), "Id", typeNameStr, Reservation?.GradeId);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Reservation == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await rsvRepository.UpdateReservation(Reservation);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
