using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentWebApi.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CardHolderName { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }
        [Column(TypeName = "varchar(3)")]
        public string SecurityCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public float Amount { get; set; }
    }
}
