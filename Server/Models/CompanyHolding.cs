using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Models
{
    public class CompanyHolding
    {
        [Key]
        [Column(Order = 0)]
        public string UserID { get; set; }

        [Column(Order = 1)]
        public string CompanyID { get; set; }

        [Required]
        [Range(0,100)]
        public int Holding { get; set; }
    }
}
