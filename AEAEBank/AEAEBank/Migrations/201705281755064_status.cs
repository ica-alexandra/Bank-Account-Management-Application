namespace AEAEBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonetaryAccountModels", "AccStatus", c => c.Int(nullable: false));
            DropColumn("dbo.MonetaryAccountModels", "Blocked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonetaryAccountModels", "Blocked", c => c.Boolean(nullable: false));
            DropColumn("dbo.MonetaryAccountModels", "AccStatus");
        }
    }
}
