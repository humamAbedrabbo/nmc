using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class RoomGrade : Entity<int>
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Room Grade (ar)")]
        public string ArName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Room Grade (en)")]
        public string EnName { get; set; }

        public int Capacity { get; set; } = 1;

    }
}
