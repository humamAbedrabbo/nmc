using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class RoomGrade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Room Grade")]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Room Grade (ar)")]
        public string NameAr { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
