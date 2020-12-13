using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum IdentityType
    {
        [Display(Name = "National")]
        National,

        [Display(Name = "Residence")]
        Residence,

        [Display(Name = "Passport")]
        Passport,

        [Display(Name = "Driving License")]
        DrivingLicense,

        [Display(Name = "Other")]
        Other
    }
}
