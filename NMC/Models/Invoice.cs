using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Invoice No.")]
        public string InvoiceNo { get; set; }

        [Display(Name = "Reservation")]
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        [Display(Name = "Admission")]
        public int? AdmissionId { get; set; }
        public Admission Admission { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Amount (SYP)")]
        public decimal Amount { get; set; }

        [Display(Name = "Status")]
        public InvoiceStatusType Status { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Expense> ExpenseItems { get; set; }
    }
}
