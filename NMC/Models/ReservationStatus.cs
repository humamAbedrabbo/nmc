using System;

namespace NMC.Models
{
    public class ReservationStatus
    {
        public DateTime StatusTime { get; set; }
        public ReservationStatusType StatusType { get; set; }
        public string Description { get; set; }
        public bool Block { get; set; }
    }
}
