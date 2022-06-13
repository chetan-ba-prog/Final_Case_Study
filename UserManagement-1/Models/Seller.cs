using System.ComponentModel.DataAnnotations;

namespace UserManagement_1.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        public string SellerName { get; set; }

        [Required, StringLength(10)]
        public string SellerMobile { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string SellerEmail { get; set; }

        [Required]
        public string SellerCategory { get; set; }

        [Required]
        public string SellerAddress { get; set; }

        [Required, DataType(DataType.Password), Compare("SellerConfPass")]
        public string SellerPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string SellerConfPass { get; set; }
    }
}
