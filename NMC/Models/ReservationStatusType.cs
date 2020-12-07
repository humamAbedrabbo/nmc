using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum ReservationStatusType
    {
        [Display(Name = "Requested")]
        Requested,

        [Display(Name = "Booked")]
        Booked,

        [Display(Name = "Pending")]
        Pending,

        [Display(Name = "Reserved")]
        Reserved,

        [Display(Name = "Cancelled")]
        Cancelled,

        [Display(Name = "Completed")]
        Completed
    }
}
