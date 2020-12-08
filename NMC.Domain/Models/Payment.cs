using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Display(Name = "Invoice")]
        public int InvoiceId { get; set; }

        [Display(Name = "Invoice")]
        public Invoice Invoice { get; set; }

        [Display(Name = "Paid Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PaidDate { get; set; }

        [Display(Name = "Paid Amount (SYP)")]
        public decimal PaidAmount { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}
