namespace WebShop3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytoMany : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EVitaminsEProducts", name: "EVitamins_Id", newName: "VitaminsId");
            RenameColumn(table: "dbo.EVitaminsEProducts", name: "EProducts_Id", newName: "ProductId");
            RenameIndex(table: "dbo.EVitaminsEProducts", name: "IX_EVitamins_Id", newName: "IX_VitaminsId");
            RenameIndex(table: "dbo.EVitaminsEProducts", name: "IX_EProducts_Id", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EVitaminsEProducts", name: "IX_ProductId", newName: "IX_EProducts_Id");
            RenameIndex(table: "dbo.EVitaminsEProducts", name: "IX_VitaminsId", newName: "IX_EVitamins_Id");
            RenameColumn(table: "dbo.EVitaminsEProducts", name: "ProductId", newName: "EProducts_Id");
            RenameColumn(table: "dbo.EVitaminsEProducts", name: "VitaminsId", newName: "EVitamins_Id");
        }
    }
}
