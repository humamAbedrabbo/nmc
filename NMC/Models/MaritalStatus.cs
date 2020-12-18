using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum MaritalStatus
    {
        [Display(Name = "Unspecified")]
        Unspecified,

        [Display(Name = "Single")]
        Single,

        [Display(Name = "Married")]
        Married
    }
}
