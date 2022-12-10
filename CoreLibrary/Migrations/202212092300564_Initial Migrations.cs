namespace CoreLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseModelDbs",
                c => new
                    {
                        _id = c.String(nullable: false, maxLength: 128),
                        ExpenseType = c.String(nullable: false),
                        Amount = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        User_UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t._id)
                .ForeignKey("dbo.UserModelDbs", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserModelDbs",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseModelDbs", "User_UserId", "dbo.UserModelDbs");
            DropIndex("dbo.ExpenseModelDbs", new[] { "User_UserId" });
            DropTable("dbo.UserModelDbs");
            DropTable("dbo.ExpenseModelDbs");
        }
    }
}
