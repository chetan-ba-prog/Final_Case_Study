using System.ComponentModel.DataAnnotations;

namespace UserManagement_1.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }

        [Required]
        public string CustName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string CustAddress { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string CustEmail { get; set; }

        [Required]
        public long CustMobile { get; set; }

        [Required, StringLength(10), DataType(DataType.Password), Compare("CustConfPass")]
        public string CustPassword { get; set; }

        [Required]
        public string CustConfPass { get; set; }
    }
}
