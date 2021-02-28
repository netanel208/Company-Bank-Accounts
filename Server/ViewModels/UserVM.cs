using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.ViewModels
{
    public class UserVM
    {
        [Required]
        public string ID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FamilyName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CompanyNumber { get; set; }
    }
}
