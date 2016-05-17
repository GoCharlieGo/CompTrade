namespace CompTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Icon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IconPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductIcon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        IconId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Icon", t => t.IconId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.IconId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Double(nullable: false),
                        ShortDiscription = c.String(),
                        Rating = c.Double(nullable: false),
                        RatingCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSpecification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SpecificationId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Specification", t => t.SpecificationId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.Specification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSpecification", "SpecificationId", "dbo.Specification");
            DropForeignKey("dbo.Specification", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ProductSpecification", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductIcon", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductIcon", "IconId", "dbo.Icon");
            DropIndex("dbo.Specification", new[] { "CategoryId" });
            DropIndex("dbo.ProductSpecification", new[] { "SpecificationId" });
            DropIndex("dbo.ProductSpecification", new[] { "ProductId" });
            DropIndex("dbo.ProductIcon", new[] { "IconId" });
            DropIndex("dbo.ProductIcon", new[] { "ProductId" });
            DropTable("dbo.Specification");
            DropTable("dbo.ProductSpecification");
            DropTable("dbo.Product");
            DropTable("dbo.ProductIcon");
            DropTable("dbo.Icon");
            DropTable("dbo.Category");
        }
    }
}
