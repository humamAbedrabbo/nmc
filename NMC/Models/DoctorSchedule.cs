using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ThruDate { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Days { get; set; }

        [Required]
        [StringLength(20)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(20)]
        public string EndTime { get; set; }

        public string Message { get; set; }
    }
}
