using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement_1.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

      /*  [Required]
        public int ProdQuantity { get; set; }*/

        [Required, ForeignKey("Product")]
        public int ProdId { get; set; }

        [Required, ForeignKey("Customer")]
        public int CustId { get; set; }

    }
}
