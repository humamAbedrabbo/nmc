using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
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
