using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum BillStatusType
    {
        [Display(Name = "Open")]
        Open,

        [Display(Name = "Partially Paid")]
        PartiallyPaid,

        [Display(Name = "Paid")]
        Paid
    }
}
