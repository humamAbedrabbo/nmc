using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum BookingStatus
    {
        [Display(Name = "Pending")]
        Pending,

        [Display(Name = "Confirmed")]
        Confirmed,

        [Display(Name = "Cancelled")]
        Cancelled
    }
}
