using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Models
{
    public class User
    {
        [Key]
        public string ID { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.Text)]
        public string FamilyName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(15)")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(16)")]
        [DataType(DataType.Text)]
        public string CompanyNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastLoginDate { get; set; }
    }
}
