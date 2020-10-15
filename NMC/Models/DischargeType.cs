using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DischargeType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string NameAr { get; set; }
    }
}
