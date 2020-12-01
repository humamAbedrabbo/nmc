using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class DepartmentRoom
    {
        public int Id { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department")]
        public Department Department { get; set; }

        [Display(Name = "Room")]
        public int RoomId { get; set; }

        [Display(Name = "Room")]
        public Room Room { get; set; }
    }
}
