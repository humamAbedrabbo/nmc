using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Date), IsUnique = false)]
    [Index(nameof(Status), IsUnique = false)]
    public class RoomAllocation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Room")]
        public Room Room { get; set; }

        [Display(Name = "Booking")]
        public int? BookingId { get; set; }

        [Display(Name = "Booking")]
        public Booking Booking { get; set; }

        [Display(Name = "Patient")]
        public int? PatientId { get; set; }

        [Display(Name = "Patient")]
        public Patient Patient { get; set; }

        [Display(Name = "Inpatient")]
        public int? InpatientId { get; set; }

        [Display(Name = "Inpatient")]
        public Inpatient Inpatient { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; } = DateTime.Today;

        public RoomStatus Status { get; set; }

        public string Text { get; set; }
    }
}
