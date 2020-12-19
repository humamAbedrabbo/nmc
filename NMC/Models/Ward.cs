using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMC.Models
{
    [Table("Wards")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    public class Ward : Entity<int>
    {
        [Display(Name = "Ward"), Required, StringLength(50)] public string Name { get; set; }
        [Display(Name = "W.Code"), Required, StringLength(5)] public string Code { get; set; }
        [Display(Name = "Floor"), Required] public int Floor { get; set; }
    }

    public enum RoomType
    {
        [Display(Name = "Ward Room")] Ward
    }

    public enum RoomGrade
    {
        [Display(Name = "Unspecified")] Unspecified,
        [Display(Name = "2nd Class")] Second,
        [Display(Name = "1st Class")] First,
        [Display(Name = "Excellent")] Excellent,
        [Display(Name = "Suite")] Suite
    }

    [Table("Rooms")]
    [Index(nameof(Code), IsUnique = true)]
    public class Room : Entity<int>
    {
        [Display(Name = "Room")] public string Name => $"{Floor}/{Code}";
        [Display(Name = "Room No."), Required, StringLength(5)] public string Code { get; set; }
        [Display(Name = "Floor"), Required] public int Floor { get; set; }
        [Display(Name = "Ward")] public int? WardId { get; set; }
        [Display(Name = "Ward")] public Ward Ward { get; set; }
        [Display(Name = "Type")] public RoomType RoomType { get; set; }
        [Display(Name = "Grade")] public RoomGrade RoomGrade { get; set; }
    }
}
