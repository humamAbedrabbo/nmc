using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Display(Name = "Reason")]
        public int? ReasonId { get; set; }

        [Display(Name = "Reason Details")]
        public string ReasonDetails { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Patient First Name")]
        public string PatientFirstName { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Patient Last Name")]
        public string PatientLastName { get; set; }

        [Display(Name = "Patient Name")]
        public string Name => $"{PatientFirstName} {PatientLastName}";

        public Gender Gender { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required, StringLength(50, MinimumLength = 1)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Confirmed On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConfirmedOn { get; set; }

        [Display(Name = "Closed On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ClosedOn { get; set; }

        [Display(Name = "Cancelled On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CancelledOn { get; set; }

        [Display(Name = "Has Payment Requirements")]
        public bool HasPaymentRequirements { get; set; }
        
        [Display(Name = "Payment Requirements")]
        public string PaymentRequirements { get; set; }

        [Display(Name = "Has Test Requirements")]
        public bool HasTestRequirements { get; set; }

        [Display(Name = "Test Requirements")]
        public string TestRequirements { get; set; }

        [Display(Name = "Has Radiology Requirements")]
        public bool HasRadiographRequirements { get; set; }

        [Display(Name = "Radiology Requirements")]
        public string RadiographRequirements { get; set; }

        [Display(Name = "Inpatient")]
        public int? InpatientId { get; set; }

        public string Notes { get; set; }

        public BookingReasonType Reason { get; set; }
        public Doctor Doctor { get; set; }
        public Inpatient Inpatient { get; set; }
        public List<Timeslot> Slots { get; set; } = new();

        public BookingStatus GetStatus()
        {
            if (CancelledOn.HasValue) return BookingStatus.Cancelled;
            if (ClosedOn.HasValue) return BookingStatus.Closed;
            if (ConfirmedOn.HasValue) return BookingStatus.Confirmed;
            if (CreatedOn.AddHours(16) < DateTime.Now) return BookingStatus.Expired;

            return BookingStatus.Pending;
        }

        public DateTime GetStatusTime()
        {
            var status = GetStatus();
            switch(status)
            {
                case BookingStatus.Cancelled:
                    return CancelledOn.Value;
                case BookingStatus.Closed:
                    return ClosedOn.Value;
                case BookingStatus.Confirmed:
                    return ConfirmedOn.Value;
                case BookingStatus.Expired:
                    return CreatedOn.AddHours(16);
                default:
                    return CreatedOn;
            }
        }

        public string GetStatusCss()
        {
            var status = GetStatus();
            switch (status)
            {
                case BookingStatus.Cancelled:
                    return "status-blue";
                case BookingStatus.Closed:
                    return "status-blue";
                case BookingStatus.Confirmed:
                    return "status-green";
                case BookingStatus.Expired:
                    return "status-red";
                
                case BookingStatus.Pending:
                default:
                    return "status-green";
            }
        }
    }

    public enum BookingStatus
    {
        Pending,
        Expired,
        Confirmed,
        Cancelled,
        Closed
    }
}
