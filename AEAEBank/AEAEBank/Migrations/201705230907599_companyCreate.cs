namespace AEAEBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionModels", "TransactionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionModels", "TransactionDate");
        }
    }
}
