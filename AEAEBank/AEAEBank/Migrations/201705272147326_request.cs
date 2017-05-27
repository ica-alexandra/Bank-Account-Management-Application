namespace AEAEBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class request : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Requests", new[] { "user_Id" });
            AddColumn("dbo.Requests", "UserName", c => c.String());
            AddColumn("dbo.Requests", "FirstName", c => c.String());
            AddColumn("dbo.Requests", "LastName", c => c.String());
            AddColumn("dbo.Requests", "Email", c => c.String());
            AddColumn("dbo.Requests", "CNP", c => c.String());
            AddColumn("dbo.Requests", "IDCardSeries", c => c.String());
            AddColumn("dbo.Requests", "IDCardNumber", c => c.String());
            AddColumn("dbo.Requests", "TelephoneNumber", c => c.String());
            AddColumn("dbo.Requests", "Address", c => c.String());
            DropColumn("dbo.Requests", "user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "user_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Requests", "Address");
            DropColumn("dbo.Requests", "TelephoneNumber");
            DropColumn("dbo.Requests", "IDCardNumber");
            DropColumn("dbo.Requests", "IDCardSeries");
            DropColumn("dbo.Requests", "CNP");
            DropColumn("dbo.Requests", "Email");
            DropColumn("dbo.Requests", "LastName");
            DropColumn("dbo.Requests", "FirstName");
            DropColumn("dbo.Requests", "UserName");
            CreateIndex("dbo.Requests", "user_Id");
            AddForeignKey("dbo.Requests", "user_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
