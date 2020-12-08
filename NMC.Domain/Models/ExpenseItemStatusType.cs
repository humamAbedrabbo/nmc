using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
{
    public enum ExpenseItemStatusType
    {
        [Display(Name = "Approved")]
        Approved,

        [Display(Name = "Pending")]
        Pending
    }
}
