using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement_1.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required, ForeignKey("Orders")]
        public int OrderId { get; set; }

        [Required, ForeignKey("Payments")]
        public int PaymentId { get; set; }

        [Required, ForeignKey("Product")]
        public int ProdId { get; set; }

        [Required, ForeignKey("Customer")]
        public int CustId { get; set; }

        [Required, ForeignKey("Seller")]
        public int SellerId { get; set; }
    }
}
