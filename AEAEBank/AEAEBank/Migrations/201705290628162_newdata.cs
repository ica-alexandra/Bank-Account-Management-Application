namespace AEAEBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        BeneficiaryIBAN = c.String(),
                        BeneficiaryName = c.String(),
                        BeneficiaryBankName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        CNP = c.String(),
                        IDCardSeries = c.String(),
                        IDCardNumber = c.String(),
                        TelephoneNumber = c.String(),
                        Address = c.String(),
                        UserPassword = c.String(),
                        RequestType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MonetaryAccountModels", "AccStatus", c => c.Int(nullable: false));
            DropColumn("dbo.MonetaryAccountModels", "Blocked");
            DropColumn("dbo.TransactionModels", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionModels", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.MonetaryAccountModels", "Blocked", c => c.Boolean(nullable: false));
            DropColumn("dbo.MonetaryAccountModels", "AccStatus");
            DropTable("dbo.Requests");
            DropTable("dbo.Companies");
        }
    }
}
