namespace Authentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStocks", "start", c => c.String());
            AddColumn("dbo.UserStocks", "end", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserStocks", "end");
            DropColumn("dbo.UserStocks", "start");
        }
    }
}
