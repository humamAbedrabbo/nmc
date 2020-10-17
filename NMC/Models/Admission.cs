using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace NMC.Models
{
    public class Admission
    {
        public int Id { get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Display(Name = "Admission Type")]
        public int AdmissionTypeId { get; set; }
        public AdmissionType AdmissionType { get; set; }

        [StringLength(50)]
        [Display(Name = "File No.")]
        public string FileNo { get; set; }

        [StringLength(50)]
        [Display(Name = "Police Ref. No.")]
        public string PoliceCode { get; set; }

        [Display(Name = "Doctor Referrer")]
        public int? ReferrerDoctorId { get; set; }
        public Doctor ReferrerDoctor { get; set; }

        [Display(Name = "Referral Letter")]
        public string ReferralLetter { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Reservation")]
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        [Display(Name = "Meals")]
        public string Meals { get; set; }

        [Display(Name = "Companion")]
        public bool Companion { get; set; }

        [Display(Name = "Medical Allergy")]
        public string MedicalAllergy { get; set; }

        [Display(Name = "Food Allergy")]
        public string FoodAllergy { get; set; }

        [Display(Name = "Admission Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AdmissionDate { get; set; }

        [Display(Name = "Admission Time")]
        public string AdmissionTime { get; set; }

        [Display(Name = "Discharge Date")]
        public DateTime? DischargeDate { get; set; }

        [Display(Name = "Discharge Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string DischargeTime { get; set; }

        [Display(Name = "Active Until")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ActiveThru { get; set; }

        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
