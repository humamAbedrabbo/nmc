using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMC.Models;
using NMC.Services;

namespace NMC.Pages.Appointments
{
    public class AddAppointmentModel : PageModel
    {
        private readonly IAppointmentRepository apptRepository;
        private readonly ITypesRepository typesRepository;

        public AddAppointmentModel(
            IAppointmentRepository apptRepository, ITypesRepository typesRepository)
        {
            this.apptRepository = apptRepository;
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Appointment Appointment { get; set; }

        public SelectList AppointmentTypesSelect { get; set; }
        public SelectList DepartmentsSelect { get; set; }
        public SelectList DoctorsSelect { get; set; }
        public SelectList PatientsSelect { get; set; }

        public async Task OnGet()
        {
            string lang = HttpContext.Request.Query["culture"];
            bool isArabic = (lang?.StartsWith("ar") ?? false);
            string typeNameStr = isArabic ? "NameAr" : "Name";
            AppointmentTypesSelect = new SelectList(await typesRepository.GetAllAppointmentTypes(), "Id", typeNameStr, Appointment?.AppointmentTypeId);
            DepartmentsSelect = new SelectList(await apptRepository.GetDepartments(), "Id", typeNameStr, Appointment?.DepartmentId);
            PatientsSelect = new SelectList(await apptRepository.GetPatients(), "Id", typeNameStr, Appointment?.PatientId);
            DoctorsSelect = new SelectList(await apptRepository.GetDoctors(), "Id", typeNameStr, Appointment?.DoctorId);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await apptRepository.AddAppointment(Appointment);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
