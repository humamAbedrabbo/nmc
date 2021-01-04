using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum DischargeType
    {
        [Display(Name = "Not Discharged")]
        NotDischarged,
        Well,
        Improvement,
        Ill,
        Death,
        Other
    }
}
