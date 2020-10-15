using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(100)]
        public string PurchaseFrom { get; set; }
        public DateTime PurchaseDate { get; set; }

        [StringLength(75)]
        public string PurchasedBy { get; set; }

        [StringLength(10)]
        public string RoomNo { get; set; }
        public decimal Amount { get; set; }
        public ExpenseItemStatusType Status { get; set; }
    }
}
