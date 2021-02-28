using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.ViewModels
{
    public class CompanyHoldingVM
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public string CompanyID { get; set; }

        [Required]
        public string Holding { get; set; }
    }
}
