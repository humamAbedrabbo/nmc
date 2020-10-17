using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DoctorEducation
    {
        public int Id { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Institution")]
        public string Institution { get; set; }

        [StringLength(100)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Degree")]
        public string Degree { get; set; }

        [StringLength(50)]
        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartingDate { get; set; }

        [Display(Name = "Completing Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CompleteDate { get; set; }
    }
}
