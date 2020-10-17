using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using NMC.Models;
using NMC.Resources;
using NMC.Services;

namespace NMC.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly IRoomRepository roomRepository;

        public IndexModel(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public IEnumerable<Room> Rooms { get; private set; }

        public async Task OnGet()
        {
            Rooms = await roomRepository.GetAllRooms();
        }
    }
}
