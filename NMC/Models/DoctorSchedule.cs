using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }

        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Thru Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime? ThruDate { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Display(Name = "Weekdays")]
        public string Days { get; set; }

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
    }
}
