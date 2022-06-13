using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement_1.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        public int RatingValue { get; set; }

        [Required]
        public string Feedback { get; set; }

        [Required, ForeignKey("Customer")]
        public int CustId { get; set; }

        [Required, ForeignKey("Product")]
        public int ProdId { get; set; }

        [Required, ForeignKey("Seller")]
        public int SellerId { get; set; }
    }
}
