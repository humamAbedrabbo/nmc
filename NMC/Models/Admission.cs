using System;
using System.Collections;
using System.Collections.Generic;

namespace NMC.Models
{
    public class Admission
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int AdmissionTypeId { get; set; }
        public AdmissionType AdmissionType { get; set; }
        public string FileNo { get; set; }
        public int? ReferrerDoctorId { get; set; }
        public Doctor ReferrerDoctor { get; set; }
        public string ReferralLetter { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public string Meals { get; set; }
        public bool Companion { get; set; }
        public string MedicalAllergy { get; set; }
        public string FoodAllergy { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string AdmissionTime { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string DischargeTime { get; set; }
        public DateTime? ActiveThru { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
