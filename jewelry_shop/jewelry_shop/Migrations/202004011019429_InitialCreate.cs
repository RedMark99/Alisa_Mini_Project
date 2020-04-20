namespace jewelry_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GramPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        RollNo = c.Int(nullable: false, identity: true),
                        TitleId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RollNo)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.TitleId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TitleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Numeric = c.Int(nullable: false, identity: true),
                        TitleId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false, storeType: "date"),
                        SName = c.String(),
                        Name = c.String(),
                        FName = c.String(),
                    })
                .PrimaryKey(t => t.Numeric)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.TitleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Products", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Products", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Sales", new[] { "TitleId" });
            DropIndex("dbo.Products", new[] { "MaterialId" });
            DropIndex("dbo.Products", new[] { "TitleId" });
            DropTable("dbo.Sales");
            DropTable("dbo.Titles");
            DropTable("dbo.Products");
            DropTable("dbo.Materials");
        }
    }
}
