namespace AEAEBank.Migrations
{
    using AEAEBank.DAL;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private ApplicationDbContext appDb = new ApplicationDbContext();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AEAEBank.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.AddUserAndRoles();
            this.AddCompanies();
            this.AddBankClients();
        }

        private void AddCompanies()
        {
            Company orange = new Company()
            {
                BeneficiaryName = "Orange",
                BeneficiaryBankName = "ING",
                BeneficiaryIBAN = "1234",
                CompanyName = "Orange",
            };

            Company cez = new Company()
            {
                BeneficiaryName = "CEZOltenia",
                BeneficiaryBankName = "ING",
                BeneficiaryIBAN = "76543218910",
                CompanyName = "CEZ",
            };

            appDb.Companies.Add(orange);
            appDb.Companies.Add(cez);

            MonetaryAccountModel orangeAcc = new MonetaryAccountModel()
            {
                UserId = "Orange",
                Amount = 300,
                IBAN = "1234",
                Currency = CurrencyType.Euro,
                Blocked = false,
            };

            MonetaryAccountModel cezAcc = new MonetaryAccountModel()
            {
                UserId = "CEZOltenia",
                Amount = 240,
                IBAN = "76543218910",
                Currency = CurrencyType.RON,
                Blocked = false,
            };

            appDb.MonetaryAccount.Add(orangeAcc);
            appDb.MonetaryAccount.Add(cezAcc);
            appDb.SaveChanges();
            
        }

        private void AddBankClients()
        {
            BankClient ion = new BankClient()
            {
                FirstName = "Ion",
                LastName = "Ionescu",
                CNP = "1234567891011",
                Email = "Ion.Ionescu@mail.com",
            };

            BankClient peter = new BankClient()
            {
                FirstName = "Peter",
                LastName = "Duncan",
                CNP = "1112131415161",
                Email = "Peter.Duncan@mail.com",
            };

            BankClient angela = new BankClient()
            {
                FirstName = "Angela",
                LastName = "Powell",
                CNP = "1718192021222",
                Email = "Angela.Powell@mail.com",
            };

            appDb.BankClients.Add(ion);
            appDb.BankClients.Add(peter);
            appDb.BankClients.Add(angela);
            appDb.SaveChanges();
        }

        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("User");
            if (!success) return success;


            var newUser = new ApplicationUser()
            {
                UserName = "Elena1920Emilia",
                FirstName = "Emilia",
                LastName = "Alexandra",
                Email = "bank@adminemail.com",
                CNP = "2950516160027",
                IDCardSeries = "DX",
                IDCardNumber = "345678",
                TelephoneNumber = "0769450266",
                Address = "str. mihaita nr. 14",
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            newUser.EmailConfirmed = true;

            success = idManager.CreateUser(newUser, "Alex_12");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            

            return success;
        }
    }
}
