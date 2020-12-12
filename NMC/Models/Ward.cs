using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Ward : Entity<int>
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Ward (ar)")]
        public string ArName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Ward (en)")]
        public string EnName { get; set; }

        [Required]
        [Display(Name = "Floor")]
        public int Floor { get; set; }
    }
}
