using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomNo { get; set; }
        public int FloorNo { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int? RoomGradeId { get; set; }
        public RoomGrade RoomGrade { get; set; }
        public int BedCount { get; set; }
        public bool Available { get; set; }
        public IEnumerable<DepartmentRoom> DepartmentRooms { get; set; }
    }
}
