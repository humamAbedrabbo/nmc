using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMC.Extensions;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.Reservations
{
    public class AddReservationModel : PageModel
    {
        private readonly IReservationRepository rsvRepository;
        private readonly ITypesRepository typesRepository;

        public AddReservationModel(
            IReservationRepository rsvRepository, ITypesRepository typesRepository)
        {
            this.rsvRepository = rsvRepository;
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Reservation Reservation { get; set; }

        public SelectList RoomsSelect { get; set; }
        public SelectList GradesSelect { get; set; }
        public SelectList PatientsSelect { get; set; }

        public async Task OnGet()
        {
            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "NameAr" : "Name";
            RoomsSelect = new SelectList(await rsvRepository.GetRooms(), "Id", "RoomNo", Reservation?.RoomNo);
            PatientsSelect = new SelectList(await rsvRepository.GetPatients(), "Id", "Name", Reservation?.PatientId);
            GradesSelect = new SelectList(await rsvRepository.GetGrades(), "Id", typeNameStr, Reservation?.GradeId);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await rsvRepository.AddReservation(Reservation);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
