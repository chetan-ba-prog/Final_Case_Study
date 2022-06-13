using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement_1.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProdId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustId { get; set; }

        [Required]
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
    }
}
