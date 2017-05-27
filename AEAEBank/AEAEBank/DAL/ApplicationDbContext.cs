using AEAEBank.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AEAEBank.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<BankClient> BankClients { get; set; }
        public DbSet<MonetaryAccountModel> MonetaryAccount { get; set; }
        public DbSet<TransactionModel> Transaction { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}