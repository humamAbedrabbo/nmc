using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class AdmissionType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Admission Type")]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Admission Type (ar)")]
        public string NameAr { get; set; }
    }
}
