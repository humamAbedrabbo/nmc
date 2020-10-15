using System.Collections.Generic;

namespace NMC.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}
