using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(BillNo), IsUnique = false)]
    [Index(nameof(CreatedOn), IsUnique = false)]
    [Index(nameof(DueDate), IsUnique = false)]
    [Index(nameof(Status), IsUnique = false)]
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Bill No.")]
        public string BillNo { get; set; }

        [Display(Name = "Inpatient")]
        public int? InpatientId { get; set; }

        [Display(Name = "Inpatient")]
        public Inpatient Inpatient { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Amount (SYP)")]
        public decimal Amount { get; set; }

        [Display(Name = "Status")]
        public BillStatusType Status { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Expense> ExpenseItems { get; set; }
    }
}
