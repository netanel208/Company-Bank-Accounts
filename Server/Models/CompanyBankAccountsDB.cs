using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Models
{
    public class CompanyBankAccountsDB: DbContext
    {
        public CompanyBankAccountsDB(DbContextOptions<CompanyBankAccountsDB> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CompanyHolding> CompaniesHoldings { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
