using System;
using System.Collections.Generic;
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
    public class EditAdmissionModel : PageModel
    {
        private readonly IAdmissionRepository admRepository;
        private readonly ITypesRepository typesRepository;

        public EditAdmissionModel(IAdmissionRepository admRepository, ITypesRepository typesRepository)
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

        public async Task<IActionResult> OnGet(int id)
        {
            Admission = await admRepository.GetAdmission(id);

            if (Admission == null)
            {
                return RedirectToPage("/NotFound");
            }

            string lang = User.GetUserLanguage();
            bool isArabic = (lang == "ar");
            string typeNameStr = isArabic ? "NameAr" : "Name";
            AdmissionTypesSelect = new SelectList(await typesRepository.GetAllAdmissionTypes(), "Id", typeNameStr, Admission?.AdmissionTypeId);
            DischargeTypesSelect = new SelectList(await typesRepository.GetAllDischargeTypes(), "Id", typeNameStr, Admission?.DischargeTypeId);
            PatientsSelect = new SelectList(await admRepository.GetPatients(), "Id", "Name", Admission?.PatientId);
            DoctorsSelect = new SelectList(await admRepository.GetDoctors(), "Id", "Name", Admission?.ReferrerDoctorId);
            DepartmentsSelect = new SelectList(await admRepository.GetDepartments(), "Id", typeNameStr, Admission?.DepartmentId);
            ReservationsSelect = new SelectList(await admRepository.GetReservations(), "Id", "RoomNo", Admission?.ReservationId);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Admission == null)
                {
                    return RedirectToPage("/NotFound");
                }

                await admRepository.UpdateAdmission(Admission);

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
