namespace Authentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStocks", "user_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserStocks", "user_Id");
            AddForeignKey("dbo.UserStocks", "user_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserStocks", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserStocks", new[] { "user_Id" });
            DropColumn("dbo.UserStocks", "user_Id");
        }
    }
}
