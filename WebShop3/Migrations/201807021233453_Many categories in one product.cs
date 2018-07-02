namespace WebShop3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Manycategoriesinoneproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblProducts", "Categories_Id", "dbo.tblCategoryProduct");
            DropIndex("dbo.tblProducts", new[] { "Categories_Id" });
            CreateTable(
                "dbo.EProductsECategoryProducts",
                c => new
                    {
                        CategoriesId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoriesId, t.ProductId })
                .ForeignKey("dbo.tblProducts", t => t.CategoriesId, cascadeDelete: true)
                .ForeignKey("dbo.tblCategoryProduct", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoriesId)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.tblProducts", "Categories_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblProducts", "Categories_Id", c => c.Int());
            DropForeignKey("dbo.EProductsECategoryProducts", "ProductId", "dbo.tblCategoryProduct");
            DropForeignKey("dbo.EProductsECategoryProducts", "CategoriesId", "dbo.tblProducts");
            DropIndex("dbo.EProductsECategoryProducts", new[] { "ProductId" });
            DropIndex("dbo.EProductsECategoryProducts", new[] { "CategoriesId" });
            DropTable("dbo.EProductsECategoryProducts");
            CreateIndex("dbo.tblProducts", "Categories_Id");
            AddForeignKey("dbo.tblProducts", "Categories_Id", "dbo.tblCategoryProduct", "Id");
        }
    }
}
