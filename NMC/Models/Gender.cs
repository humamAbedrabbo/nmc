using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female
    }
}
