namespace WebShop3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ForgotToken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ForgotToken", c => c.String(maxLength: 255));
        }
    }
}
