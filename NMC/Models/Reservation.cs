using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NMC.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [StringLength(10)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Room No.")]
        public Room Room { get; set; }

        [Display(Name = "Room Grade")]
        public int? GradeId { get; set; }

        [Display(Name = "Room Grade")]
        public RoomGrade Grade { get; set; }

        [StringLength(10)]
        [Display(Name = "Bed No.")]
        public string BedNo { get; set; }

        [Display(Name = "Reserved Beds")]
        public int ReservedBeds { get; set; }

        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FromDate { get; set; } = DateTime.Today;

        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Display(Name = "To Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ToDate { get; set; } = DateTime.Today;

        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Requestor")]
        public string Requestor { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(75)]
        [Display(Name = "Patient Name")]
        public string Name { get; set; }

        [StringLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(30)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Patient")]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Display(Name = "Status Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StatusTime { get; set; } = DateTime.Now;

        [Display(Name = "Status Type")]
        public ReservationStatusType Status { get; set; }

        private string ToDateStr => (ToDate.Date == FromDate.Date) ? "" : $"{ToDate.ToShortDateString()} ";
        
        [Display(Name = "Reservation Period")]
        public string ReservationPeriod => $"{FromDate.ToShortDateString()} {StartTime} - {ToDateStr}{EndTime}";

        public string ActiveText => Active ? "Active" : "Inactive";
        public string ActiveCSS => Active ? "status-green" : "status-red";

        public IEnumerable<Invoice> Invoices { get; set; }

    }
}
