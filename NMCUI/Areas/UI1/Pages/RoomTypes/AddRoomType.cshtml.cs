using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.RoomTypes
{
    public class AddRoomTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public AddRoomTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public RoomType RoomType { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await typesRepository.AddRoomType(RoomType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
