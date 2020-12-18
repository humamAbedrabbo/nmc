using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NMC.Models
{
    [Index(nameof(Bed), IsUnique = false)]
    [Index(nameof(AdmissionDate), IsUnique = false)]
    [Index(nameof(DischargeDate), IsUnique = false)]
    [Index(nameof(GLAccount), IsUnique = false)]
    [Index(nameof(FileNo), IsUnique = false)]
    [Index(nameof(PoliceRef), IsUnique = false)]
    [Index(nameof(Active), IsUnique = false)]
    public class Inpatient
    {
        public int Id { get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Display(Name = "Patient")]
        public Patient Patient { get; set; } = new();

        [Display(Name = "Patient")]
        public string Name => Patient?.Name;
        
        [Display(Name = "Identity")]
        public string IdentityNo => Patient?.IdentityNo;
        
        [Display(Name = "Gender")]
        public string Gender => Patient?.Gender.ToString() ?? "";

        [Display(Name = "Booking")]
        public int? BookingId { get; set; }

        public Booking Booking { get; set; }

        [Display(Name = "Referrer")]
        public int? ReferrerId { get; set; }

        public Doctor Referrer { get; set; }

        [Display(Name = "Ward")]
        public int WardId { get; set; }

        [Display(Name = "Ward")]
        public Ward Ward { get; set; }
        
        [StringLength(5, MinimumLength = 1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Room")]
        public Room Room { get; set; }

        [Display(Name = "Room Grade")]
        public int? RoomGradeId { get; set; }

        [Display(Name = "Room Grade")]
        public RoomGrade RoomGrade { get; set; }

        public int GradeLevelFactor { get; set; }

        public bool IsUpgrade => GradeLevelFactor > 0;
        public bool IsDowngrade => GradeLevelFactor < 0;

        [StringLength(50)]
        public string Bed { get; set; }

        public DateTime? BarCodeGenerated { get; set; }

        public string BarCodeUrl { get; set; }

        [Display(Name = "Status")]
        public int? StatusId { get; set; }

        public InpatientStatus Status => Statuses.OrderByDescending(x => x.StatusTime).FirstOrDefault();

        [Display(Name = "File No.")]
        public string FileNo { get; set; }

        [Display(Name = "Admission Type")]
        public int? AdmissionTypeId { get; set; }

        [Display(Name = "Admission Type")]
        public AdmissionType AdmissionType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Admet On")]
        public DateTime? AdmissionDate { get; set; }

        [Display(Name = "Admission Note")]
        public string AdmissionNote { get; set; }

        [Display(Name = "Police Ref.")]
        public string PoliceRef { get; set; }

        [Display(Name = "Discharge Type")]
        public int? DischargeTypeId { get; set; }

        [Display(Name = "Discharge Type")]
        public DischargeType DischargeType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Discharged On")]
        public DateTime? DischargeDate { get; set; }

        [Display(Name = "Discharge Note")]
        public string DischargeNote { get; set; }

        public bool Deceased { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deceased On")]
        public DateTime? DeceasedDate { get; set; }

        [Display(Name = "Decease Note")]
        public string DeceaseNote { get; set; }

        public string Companion { get; set; }

        public string Meals { get; set; }

        [Display(Name = "Medical Allergies")]
        public string MedicalAllergies { get; set; }

        [Display(Name = "Medical Allergy Note")]
        public string MedicalAllergyNote { get; set; }

        [Display(Name = "Food Allergies")]
        public string FoodAllergies { get; set; }

        [Display(Name = "Food Allergy Note")]
        public string FoodAllergyNote { get; set; }

        public string Diabeties { get; set; }

        [Display(Name = "Diabeties Notes")]
        public string DiabetiesNotes { get; set; }

        public string Diseases { get; set; }

        [Display(Name = "Diseases Notes")]
        public string DiseasesNotes { get; set; }

        public string Medicines { get; set; }
        
        [Display(Name = "Medicines Notes")]
        public string MedicinesNotes { get; set; }

        public string Smoking { get; set; }
        public string Alcohol { get; set; }

        [Display(Name = "Min. Down Payment")]
        public int MinDownPayment { get; set; }

        [StringLength(30)]
        [Display(Name = "GL. Account")]
        public string GLAccount { get; set; }

        public bool Active { get; set; } = true;

        public List<RoomAllocation> Allocations { get; set; } = new();
        public List<InpatientStatus> Statuses { get; set; } = new();
        public List<Bill> Bills { get; set; } = new();
    }
}
