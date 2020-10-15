using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class RoomGrade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string NameAr { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
