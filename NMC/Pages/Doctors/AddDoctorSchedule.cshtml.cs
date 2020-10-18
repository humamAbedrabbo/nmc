using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMC.Models;
using NMC.Services;

namespace NMC.Pages.Doctors
{
    public class AddDoctorScheduleModel : PageModel
    {
        private readonly IDoctorRepository doctorRepository;
        private string[] weekdays = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        public AddDoctorScheduleModel(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        [BindProperty(SupportsGet = true)]
        public DoctorSchedule DoctorSchedule { get; set; }

        public SelectList DoctorsSelect { get; set; }

        public MultiSelectList DaysSelect { get; set; }

        public async Task OnGet()
        {
            DoctorsSelect = new SelectList(await doctorRepository.GetAllDoctors(), "Id", "Name", DoctorSchedule?.DoctorId);
            DaysSelect = new MultiSelectList(weekdays, DoctorSchedule?.DaysList);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                DoctorSchedule = await doctorRepository.AddDoctorSchedule(DoctorSchedule);

                return RedirectToPage("DoctorScheduleIndex");
            }

            return Page();
        }
    }
}
