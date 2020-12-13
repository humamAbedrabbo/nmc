using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum RH
    {
        [Display(Name = "Unknwon")]
        Unknown,

        [Display(Name = "+")]
        Positive,

        [Display(Name = "-")]
        Negative
    }
}
