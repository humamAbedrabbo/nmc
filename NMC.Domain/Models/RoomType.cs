using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
{
    public class RoomType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Room Type")]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Room Type (ar)")]
        public string NameAr { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
