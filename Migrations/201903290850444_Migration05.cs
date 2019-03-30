namespace Authentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStocks", "Change", c => c.Double());
            AddColumn("dbo.UserStocks", "ChangePercent", c => c.Double(nullable: false));
            DropColumn("dbo.UserStocks", "start");
            DropColumn("dbo.UserStocks", "end");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserStocks", "end", c => c.String());
            AddColumn("dbo.UserStocks", "start", c => c.String());
            DropColumn("dbo.UserStocks", "ChangePercent");
            DropColumn("dbo.UserStocks", "Change");
        }
    }
}
