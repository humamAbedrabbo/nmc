﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    [Index(nameof(AdmissionDate), IsUnique = false)]
    [Index(nameof(DischargeDate), IsUnique = false)]
    [Index(nameof(DischargeType), IsUnique = false)]
    [Index(nameof(CreatedBy), IsUnique = false)]
    [Index(nameof(CreatedOn), IsUnique = false)]
    public class Inpatient
    {
        public int Id { get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Display(Name = "Room")]
        public int? CurrentRoomId { get; set; }

        [Display(Name = "Doctor")]
        public int? DoctorId { get; set; }

        [Display(Name = "Booking")]
        public int? BookingId { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Admission Time")]
        public DateTime? AdmissionDate { get; set; }

        [Display(Name = "Est. Days")]
        public int EstDays { get; set; } = 1;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Est. Discharge Date")]
        public DateTime? EstDischargeDate
        {
            get
            {
                if (AdmissionDate.HasValue)
                {
                    return AdmissionDate.Value.AddDays(EstDays).AddMinutes(-1);
                }
                else
                    return null;
            }
        }
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Discharge Date")]
        public DateTime? DischargeDate { get; set; }

        [Display(Name = "Discharge Type")]
        public DischargeType DischargeType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Emergency")]
        public bool IsEmergency { get; set; }

        [Display(Name = "Accident")]
        public bool IsAccident { get; set; }

        [StringLength(50)]
        [Display(Name = "Police Ref.")]
        public string PoliceRef { get; set; }

        [Display(Name = "Companion")]
        public bool HasCompanion { get; set; }

        public Patient Patient { get; set; }
        public Room CurrentRoom { get; set; }
        public Doctor Doctor { get; set; }
        public Booking Booking { get; set; }
        public List<Timeslot> Slots { get; set; } = new();

        public InpatientStatus GetStatus()
        {
            if(DischargeDate.HasValue) return InpatientStatus.Discharged;
            if (AdmissionDate.HasValue && CurrentRoomId.HasValue) return InpatientStatus.Admitted;

            return InpatientStatus.Pending;
        }

        public DateTime GetStatusTime()
        {
            var status = GetStatus();
            switch(status)
            {
                case InpatientStatus.Discharged:
                    return DischargeDate.Value;
                case InpatientStatus.Admitted:
                    return AdmissionDate.Value;
                default:
                    return CreatedOn;
            }
        }
    }
}
