namespace WebShop3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastChangeinproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblProducts", "LastChange", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblProducts", "LastChange");
        }
    }
}
