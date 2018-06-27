namespace WebShop3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblProductVitaminsCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategoryProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Discription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Discription = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblVitamins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Discription = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EProductsECategoryProducts",
                c => new
                    {
                        EProducts_Id = c.Int(nullable: false),
                        ECategoryProduct_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EProducts_Id, t.ECategoryProduct_Id })
                .ForeignKey("dbo.tblProducts", t => t.EProducts_Id, cascadeDelete: true)
                .ForeignKey("dbo.tblCategoryProduct", t => t.ECategoryProduct_Id, cascadeDelete: true)
                .Index(t => t.EProducts_Id)
                .Index(t => t.ECategoryProduct_Id);
            
            CreateTable(
                "dbo.EVitaminsEProducts",
                c => new
                    {
                        EVitamins_Id = c.Int(nullable: false),
                        EProducts_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EVitamins_Id, t.EProducts_Id })
                .ForeignKey("dbo.tblVitamins", t => t.EVitamins_Id, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.EProducts_Id, cascadeDelete: true)
                .Index(t => t.EVitamins_Id)
                .Index(t => t.EProducts_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EVitaminsEProducts", "EProducts_Id", "dbo.tblProducts");
            DropForeignKey("dbo.EVitaminsEProducts", "EVitamins_Id", "dbo.tblVitamins");
            DropForeignKey("dbo.EProductsECategoryProducts", "ECategoryProduct_Id", "dbo.tblCategoryProduct");
            DropForeignKey("dbo.EProductsECategoryProducts", "EProducts_Id", "dbo.tblProducts");
            DropIndex("dbo.EVitaminsEProducts", new[] { "EProducts_Id" });
            DropIndex("dbo.EVitaminsEProducts", new[] { "EVitamins_Id" });
            DropIndex("dbo.EProductsECategoryProducts", new[] { "ECategoryProduct_Id" });
            DropIndex("dbo.EProductsECategoryProducts", new[] { "EProducts_Id" });
            DropTable("dbo.EVitaminsEProducts");
            DropTable("dbo.EProductsECategoryProducts");
            DropTable("dbo.tblVitamins");
            DropTable("dbo.tblProducts");
            DropTable("dbo.tblCategoryProduct");
        }
    }
}
