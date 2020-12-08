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

namespace NMCUI.Areas.UI1.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentRepository apptRepository;

        public IndexModel(IAppointmentRepository apptRepository)
        {
            this.apptRepository = apptRepository;
        }

        public IEnumerable<Appointment> Appointments { get; private set; }

        public async Task OnGet()
        {
            Appointments = await apptRepository.GetAllAppointments();
        }
    }
}
