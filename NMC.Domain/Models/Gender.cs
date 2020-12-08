using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female
    }
}
