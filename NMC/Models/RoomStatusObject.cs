using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class RoomStatusObject
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public int FloorNo { get; set; }
        public int WardId { get; set; }
        public string WardName { get; set; }
        public int? BookingId { get; set; }
        public string BookingName { get; set; }
        public DateTime Date { get; set; }
        public RoomStatusType Status { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
