using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement_1.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required, ForeignKey("Product")]
        public int ProdId { get; set; }

        [Required, ForeignKey("Customer")]
        public int CustId { get; set; }

        [Required, ForeignKey("Payment")]
        public int PaymentId { get; set; }

        [Required, ForeignKey("Seller")]
        public int SellerId { get; set; }
    }
}
