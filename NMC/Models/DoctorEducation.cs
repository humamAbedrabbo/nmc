using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DoctorEducation
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        [StringLength(100)]
        public string Institution { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        [StringLength(100)]
        public string Degree { get; set; }

        [StringLength(50)]
        public string Grade { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}
