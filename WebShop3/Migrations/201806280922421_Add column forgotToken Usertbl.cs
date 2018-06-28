namespace WebShop3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnforgotTokenUsertbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ForgotToken", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ForgotToken");
        }
    }
}
