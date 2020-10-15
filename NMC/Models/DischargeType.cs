using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DischargeType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Discharge Type")]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Discharge Type (ar)")]
        public string NameAr { get; set; }
    }
}
