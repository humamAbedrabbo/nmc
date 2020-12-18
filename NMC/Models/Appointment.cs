using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(AppointmentDate), IsUnique = false)]
    [Index(nameof(Phone), IsUnique = false)]
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Appointment Type")]
        public int AppointmentTypeId { get; set; }

        [Display(Name = "Appointment Type")]
        public AppointmentType AppointmentType { get; set; }

        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AppointmentDate { get; set; } = DateTime.Today;

        [Required]
        [StringLength(20)]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Visitor")]
        public string Visitor { get; set; }

        [Display(Name = "Patient")]
        public int? PatientId { get; set; }

        [Display(Name = "Patient")]
        public Patient Patient { get; set; }

        [StringLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(30)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Doctor")]
        public int? DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        [Display(Name = "Ward")]
        public int? WardId { get; set; }
        public Ward Ward { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Display(Name = "Appointment Time")]
        public string AppointmentTime => $"{StartTime} - {EndTime}";

        public string ActiveText => Active ? "Active" : "Inactive";
        public string ActiveCSS => Active ? "status-green" : "status-red";

    }
}
