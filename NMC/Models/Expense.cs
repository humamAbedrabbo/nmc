using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace NMC.Models
{
    [Index(nameof(ItemCode), IsUnique = false)]
    [Index(nameof(PurchaseDate), IsUnique = false)]
    [Index(nameof(RoomNo), IsUnique = false)]
    [Index(nameof(Status), IsUnique = false)]
    public class Expense
    {
        public int Id { get; set; }

        [Display(Name = "Bill")]
        public int BillId { get; set; }

        [Display(Name = "Bill")]
        public Bill Bill { get; set; }

        [StringLength(50)]
        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Item Description")]
        public string Description { get; set; }

        [StringLength(100)]
        [Display(Name = "Purchase From")]
        public string PurchaseFrom { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PurchaseDate { get; set; }

        [StringLength(75)]
        [Display(Name = "Purchase By")]
        public string PurchasedBy { get; set; }

        [StringLength(10)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Amount (SYP)")]
        public decimal Amount { get; set; }

        [Display(Name = "Status")]
        public ExpenseItemStatusType Status { get; set; }
    }
}
