using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum ModuleName
    {
        [Display(Name = "Employee")]
        Employee,

        [Display(Name = "Reservation")]
        Reservation,

        [Display(Name = "Doctor")]
        Doctor,

        [Display(Name = "Admission")]
        Admission,

        [Display(Name = "Accounting")]
        Accounting
    }
}
