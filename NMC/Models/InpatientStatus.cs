using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(Name), IsUnique = false)]
    [Index(nameof(StatusTime), IsUnique = false)]
    public class InpatientStatus
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Inpatient")]
        public int InpatientId { get; set; }

        [Display(Name = "Inpatient")]
        public Inpatient Inpatient { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Status Time")]
        public DateTime StatusTime { get; set; } = DateTime.Now;

        public string Description { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
