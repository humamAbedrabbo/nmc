using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Booking : Entity<int>
    {
        [Required]
        [Display(Name = "Booking Name")]
        public string Name { get; set; }

        [Display(Name = "Doctor")]
        public int? DoctorId { get; set; }

        [Display(Name = "Doctor")]
        public Doctor Doctor { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Patient First Name")]
        public string PatientFirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [Display(Name = "Patient Last Name")]
        public string PatientLastName { get; set; }

        [MaxLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Ward")]
        public int WardId { get; set; }

        [Display(Name = "Ward")]
        public Ward Ward { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Down Payment")]
        public decimal DownPayment { get; set; }

        [Display(Name = "Amount Received")]
        public decimal AmountReceived { get; set; }

        [Display(Name = "From")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; } = DateTime.Today;

        [Display(Name = "To")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime To { get; set; } = DateTime.Today.AddDays(1);

        [Display(Name = "Status")]
        public BookingStatus Status { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Valid Until")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime ValidUntil { get; set; }

        [Display(Name = "Confirmation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime? ConfirmationDate { get; set; }

        [Display(Name = "Expired")]
        public bool Expired => Status == BookingStatus.Pending && DateTime.Today > ValidUntil;
    }
}
