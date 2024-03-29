using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using NMC.Domain.Models;

using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly IReservationRepository rsvRepository;

        public IndexModel(IReservationRepository rsvRepository)
        {
            this.rsvRepository = rsvRepository;
        }

        public IEnumerable<Reservation> Reservations { get; private set; }

        public async Task OnGet()
        {
            Reservations = await rsvRepository.GetAllReservations();
        }
    }
}
