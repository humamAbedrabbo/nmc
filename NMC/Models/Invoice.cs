using System;
using System.Collections.Generic;

namespace NMC.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int? AdmissionId { get; set; }
        public Admission Admission { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal Amount { get; set; }
        public InvoiceStatusType Status { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Expense> ExpenseItems { get; set; }
    }
}
