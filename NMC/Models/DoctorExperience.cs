using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DoctorExperience
    {
        public int Id { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [StringLength(50)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Period From")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PeriodFrom { get; set; }

        [Display(Name = "Period To")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PeriodTo { get; set; }
    }
}
