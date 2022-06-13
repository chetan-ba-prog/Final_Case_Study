using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement_1.Models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }

        [Required]
        public string ProdName { get; set; }

        [Required]
        public string ProdDesc{ get; set; }

        [Required]
        public string ProdImage { get; set; }

        [Required]
        public string ProdCategory { get; set; }

        [Required]
        public float ProdPrice { get; set; }

        [Required]
        public float ProdDiscount { get; set; }

        [Required]
        public string ProdStatus { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

    }
}
