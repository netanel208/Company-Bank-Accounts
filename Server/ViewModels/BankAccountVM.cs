using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.ViewModels
{
    public class BankAccountVM
    {
        public string ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CompanyID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string BankName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string BankBranch { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string AccountNumber { get; set; }
    }
}
