using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMC.Models
{
    [Table("Wards")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    public class Ward : Entity<int>
    {
        [Display(Name = "Ward"), Required, StringLength(50)] public string Name { get; set; }
        [Display(Name = "W.Code"), Required, StringLength(5)] public string Code { get; set; }
        [Display(Name = "Floor"), Required] public int Floor { get; set; }
    }
}
