using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.RoomGrades
{
    public class EditRoomGradeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public EditRoomGradeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public RoomGrade RoomGrade { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            RoomGrade = await typesRepository.GetRoomGrade(id);

            if (RoomGrade == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (RoomGrade == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await typesRepository.UpdateRoomGrade(RoomGrade);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
