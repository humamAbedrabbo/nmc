using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMC.Extensions;
using NMC.Domain.Models;
using NMC.Core.Services;

namespace NMCUI.Areas.UI1.Pages.Admissions
{
    public class AddAdmissionModel : PageModel
    {
        private readonly IAdmissionRepository admRepository;
        private readonly ITypesRepository typesRepository;

        public AddAdmissionModel(
            IAdmissionRepository admRepository, ITypesRepository typesRepository)
        {
            this.admRepository = admRepository;
            this.typesRepository = typesRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Admission Admission { get; set; }

        public SelectList AdmissionTypesSelect { get; set; }
        public SelectList DischargeTypesSelect { get; set; }
        public SelectList DoctorsSelect { get; set; }
        public SelectList DepartmentsSelect { get; set; }
        public SelectList ReservationsSelect { get; set; }
        public SelectList PatientsSelect { get; set; }

        public async Task OnGet()
        {
            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "NameAr" : "Name";
            AdmissionTypesSelect = new SelectList(await typesRepository.GetAllAdmissionTypes(), "Id", typeNameStr, Admission?.AdmissionTypeId);
            DischargeTypesSelect = new SelectList(await typesRepository.GetAllDischargeTypes(), "Id", typeNameStr, Admission?.DischargeTypeId);
            PatientsSelect = new SelectList(await admRepository.GetPatients(), "Id", "Name", Admission?.PatientId);
            DoctorsSelect = new SelectList(await admRepository.GetDoctors(), "Id", "Name", Admission?.ReferrerDoctorId);
            DepartmentsSelect = new SelectList(await admRepository.GetDepartments(), "Id", typeNameStr, Admission?.DepartmentId);
            ReservationsSelect = new SelectList(await admRepository.GetReservations(), "Id", "RoomNo", Admission?.ReservationId);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await admRepository.AddAdmission(Admission);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
