namespace WebShop3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountandImagetoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblProducts", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblProducts", "Image");
            DropColumn("dbo.tblProducts", "Count");
        }
    }
}
