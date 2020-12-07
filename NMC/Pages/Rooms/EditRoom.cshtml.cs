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

namespace NMC.Pages.Rooms
{
    public class EditRoomModel : PageModel
    {
        private readonly IRoomRepository roomRepository;
        private readonly ITypesRepository typesRepository;

        public EditRoomModel(IRoomRepository roomRepository, ITypesRepository typesRepository)
        {
            this.roomRepository = roomRepository;
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Room Room { get; set; }

        public SelectList RoomTypesSelect { get; set; }

        public SelectList RoomGradesSelect { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Room = await roomRepository.GetRoom(id);

            if (Room == null)
            {
                return RedirectToPage("/NotFound");
            }

            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string roomTypeNameStr = isArabic ? "NameAr" : "Name";
            RoomTypesSelect = new SelectList(await typesRepository.GetAllRoomTypes(), "Id", roomTypeNameStr, Room?.RoomTypeId);
            RoomGradesSelect = new SelectList(await typesRepository.GetAllRoomGrades(), "Id", roomTypeNameStr, Room?.RoomGradeId);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Room == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await roomRepository.UpdateRoom(Room);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
