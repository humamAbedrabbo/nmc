using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using NMC.Models;

using NMC.Services;

namespace NMC.Pages.Doctors
{
    public class DoctorScheduleIndexModel : PageModel
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorScheduleIndexModel(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorSchedule> DoctorSchedules { get; private set; }

        public async Task OnGet()
        {
            DoctorSchedules = await doctorRepository.GetAllDoctorSchedules();
        }
    }
}