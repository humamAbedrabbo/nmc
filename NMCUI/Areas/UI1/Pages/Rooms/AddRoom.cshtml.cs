using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMC.Extensions;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.Rooms
{
    public class AddRoomModel : PageModel
    {
        private readonly IRoomRepository roomRepository;
        private readonly ITypesRepository typesRepository;

        public AddRoomModel(IRoomRepository roomRepository, ITypesRepository typesRepository)
        {
            this.roomRepository = roomRepository;
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Room Room { get; set; }

        public SelectList RoomTypesSelect { get; set; }

        public SelectList RoomGradesSelect { get; set; }
        
        public SelectList WardsSelect { get; set; }

        public async Task OnGet()
        {
            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string roomTypeNameStr = isArabic ? "NameAr" : "Name";
            string departmentNameStr = isArabic ? "NameAr" : "Name";
            RoomTypesSelect = new SelectList(await typesRepository.GetAllRoomTypes(), "Id", roomTypeNameStr, Room?.RoomTypeId);
            RoomGradesSelect = new SelectList(await typesRepository.GetAllRoomGrades(), "Id", roomTypeNameStr, Room?.RoomGradeId);
            WardsSelect = new SelectList(await roomRepository.GetDepartments(), "Id", departmentNameStr, Room?.WardId);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await roomRepository.AddRoom(Room);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
