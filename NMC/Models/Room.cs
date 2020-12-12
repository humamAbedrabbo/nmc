using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Room : Entity<int>
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Room Grade")]
        public int RoomGradeId { get; set; }

        [Display(Name = "Room Grade")]
        public RoomGrade RoomGrade { get; set; }

        [Display(Name = "Ward")]
        public int WardId { get; set; }

        [Display(Name = "Ward")]
        public Ward Ward { get; set; }

        public RoomStatusType GetCurrentStatus()
        {
            return RoomStatusType.Available;
        }
    }
}
