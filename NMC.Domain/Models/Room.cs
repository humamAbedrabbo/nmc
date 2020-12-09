using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Floor No.")]
        public int FloorNo { get; set; }

        [Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }

        [Display(Name = "Room Grade")]
        public int? RoomGradeId { get; set; }

        [Display(Name = "Room Grade")]
        public RoomGrade RoomGrade { get; set; }

        [Display(Name = "Ward")]
        public int? WardId { get; set; }

        [Display(Name = "Ward")]
        public Department Ward { get; set; }

        [Display(Name = "Bed Count")]
        public int BedCount { get; set; }

        [Display(Name = "Available")]
        public bool Available { get; set; }

        public string AvailableText => Available ? "Available" : "Not Available";
        public string AvailableCSS => Available ? "status-green" : "status-red";

        public IEnumerable<DepartmentRoom> DepartmentRooms { get; set; }
    }
}
