using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NMC.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }

        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FromDate { get; set; } = DateTime.Today;

        [Display(Name = "Thru Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ThruDate { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        [Display(Name = "Available Days")]
        public string Days { get; set; }

        [NotMapped]
        public string[] DaysList
        {
            get => Days?.Split(" ");
            set => Days = string.Join(" ", value);
        }

        [Required]
        [StringLength(20)]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Timing")]
        public string Timing => $"{StartTime} - {EndTime}";
    }
}
