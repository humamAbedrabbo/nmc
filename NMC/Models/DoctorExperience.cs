using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DoctorExperience
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
    }
}
