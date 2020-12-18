using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(PaidDate), IsUnique = false)]
    public class Payment
    {
        public int Id { get; set; }

        [Display(Name = "Bill")]
        public int BillId { get; set; }

        [Display(Name = "Bill")]
        public Bill Bill { get; set; }

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
