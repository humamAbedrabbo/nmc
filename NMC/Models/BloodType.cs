using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum BloodType
    {
        [Display(Name = "Unknwon")]
        Unknown,
        A,
        B,
        AB,
        O
    }
}
