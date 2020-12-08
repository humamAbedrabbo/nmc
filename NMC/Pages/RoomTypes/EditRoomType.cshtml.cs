using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMC.Pages.RoomTypes
{
    public class EditRoomTypeModel : PageModel
    {
        private readonly ITypesRepository typesRepository;

        public EditRoomTypeModel(ITypesRepository typesRepository)
        {
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public RoomType RoomType { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            RoomType = await typesRepository.GetRoomType(id);

            if (RoomType == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (RoomType == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await typesRepository.UpdateRoomType(RoomType);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
