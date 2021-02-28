using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Models
{
    public class BankAccount
    {
        [Key]
        public int ID { get; set; } //Auto increment

        [Required]
        public string UserID { get; set; }

        [Required]
        public string CompanyID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.Text)]
        public string BankName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.Text)]
        public string BankBranch { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [DataType(DataType.Text)]
        public string AccountNumber { get; set; }
    }
}
