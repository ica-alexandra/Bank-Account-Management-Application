namespace AEAEBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserPassword = c.String(),
                        RequestType = c.String(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Requests", new[] { "user_Id" });
            DropTable("dbo.Requests");
        }
    }
}
