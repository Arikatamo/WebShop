namespace WebShop3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class producthasonecategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EProductsECategoryProducts", "EProducts_Id", "dbo.tblProducts");
            DropForeignKey("dbo.EProductsECategoryProducts", "ECategoryProduct_Id", "dbo.tblCategoryProduct");
            DropIndex("dbo.EProductsECategoryProducts", new[] { "EProducts_Id" });
            DropIndex("dbo.EProductsECategoryProducts", new[] { "ECategoryProduct_Id" });
            AddColumn("dbo.tblProducts", "Categories_Id", c => c.Int());
            CreateIndex("dbo.tblProducts", "Categories_Id");
            AddForeignKey("dbo.tblProducts", "Categories_Id", "dbo.tblCategoryProduct", "Id");
            DropTable("dbo.EProductsECategoryProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EProductsECategoryProducts",
                c => new
                    {
                        EProducts_Id = c.Int(nullable: false),
                        ECategoryProduct_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EProducts_Id, t.ECategoryProduct_Id });
            
            DropForeignKey("dbo.tblProducts", "Categories_Id", "dbo.tblCategoryProduct");
            DropIndex("dbo.tblProducts", new[] { "Categories_Id" });
            DropColumn("dbo.tblProducts", "Categories_Id");
            CreateIndex("dbo.EProductsECategoryProducts", "ECategoryProduct_Id");
            CreateIndex("dbo.EProductsECategoryProducts", "EProducts_Id");
            AddForeignKey("dbo.EProductsECategoryProducts", "ECategoryProduct_Id", "dbo.tblCategoryProduct", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EProductsECategoryProducts", "EProducts_Id", "dbo.tblProducts", "Id", cascadeDelete: true);
        }
    }
}
