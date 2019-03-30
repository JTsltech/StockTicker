namespace Authentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration04 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ticker = c.String(),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockLists");
        }
    }
}
