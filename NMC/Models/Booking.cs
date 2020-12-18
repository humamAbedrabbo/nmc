using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = false)]
    [Index(nameof(RequestDate), IsUnique = false)]
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Display(Name = "Doctor")]
        public int? DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        public string Message { get; set; }

        [Display(Name = "Down Payment")]
        [Range(0, int.MaxValue)]
        public int DownPayment { get; set; }

        public bool Active { get; set; } = true;

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [NotMapped]
        [Display(Name = "Room No.")]
        public string RoomNo => Allocations?.Select(x => x.RoomNo).FirstOrDefault();

        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime From => Allocations?.Min(x => x.Date) ?? RequestDate;

        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime To => Allocations?.Max(x => x.Date) ?? RequestDate;

        public RoomStatus Status => Allocations.FirstOrDefault().Status;

        [NotMapped]
        public bool CanBeCancelled => !(Status == RoomStatus.Reserved && Allocations.Any(x => x.InpatientId.HasValue));

        public List<RoomAllocation> Allocations { get; set; } = new();

    }
}
