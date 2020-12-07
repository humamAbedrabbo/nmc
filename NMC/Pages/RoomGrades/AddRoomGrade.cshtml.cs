using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Models;
using NMC.Services;

namespace NMC.Pages.RoomGrades
{
    public class AddRoomGradeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public AddRoomGradeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public RoomGrade RoomGrade { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await typesRepository.AddRoomGrade(RoomGrade);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
