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
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AEAEBank.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.AddUserAndRoles();
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
