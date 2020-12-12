using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public enum RoomStatusType
    {
        [Display(Name = "Available")]
        Available,

        [Display(Name = "Booked")]
        Booked,

        [Display(Name = "Reserved")]
        Reserved
    }
}
