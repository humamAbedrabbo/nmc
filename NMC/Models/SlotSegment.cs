using System;

namespace NMC.Models
{
    public class SlotSegment
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public RoomStatus Status { get; set; }
        public override string ToString()
        {
            return $"{Start.ToString("hhtt")}-{End.ToString("hhtt")}";
        }
    }
}
