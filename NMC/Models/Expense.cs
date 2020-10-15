using System;

namespace NMC.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public string Description { get; set; }
        public string PurchaseFrom { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchasedBy { get; set; }
        public decimal Amount { get; set; }
        public ExpenseItemStatusType Status { get; set; }
    }
}
