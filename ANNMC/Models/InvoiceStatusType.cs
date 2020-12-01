using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum InvoiceStatusType
    {
        [Display(Name = "Open")]
        Open,

        [Display(Name = "Partially Paid")]
        PartiallyPaid,

        [Display(Name = "Paid")]
        Paid
    }
}
