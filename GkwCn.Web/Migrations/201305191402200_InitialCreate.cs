namespace GkwCn.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Statue = c.Int(nullable: false),
                        Level = c.Byte(nullable: false),
                        LoginName = c.String(nullable: false, maxLength: 16),
                        Password = c.String(nullable: false, maxLength: 16),
                        Email = c.String(maxLength: 50),
                        Handset = c.String(maxLength: 20),
                        Address = c.String(maxLength: 100),
                        Sex = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        LastLoginTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegUserLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Message = c.String(),
                        Type = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        LogoId = c.Int(nullable: false),
                        Sequence = c.String(),
                        OldId = c.String(maxLength: 19),
                        Statue = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Level = c.Byte(nullable: false),
                        ChildCount = c.Byte(nullable: false),
                        Sequence = c.String(),
                        OldId = c.String(maxLength: 19),
                        Statue = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogoSrc = c.String(),
                        LinkUrl = c.String(),
                        OldId = c.String(maxLength: 19),
                        Statue = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Level = c.Byte(nullable: false),
                        ChildCount = c.Byte(nullable: false),
                        Sequence = c.String(),
                        OldId = c.String(maxLength: 19),
                        Statue = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProvinceCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        ParentId = c.Int(),
                        Level = c.Byte(nullable: false),
                        ChildCount = c.Byte(nullable: false),
                        Sequence = c.String(),
                        OldId = c.String(maxLength: 19),
                        Statue = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OldId = c.String(maxLength: 19),
                        Statue = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsType = c.Int(nullable: false),
                        OldId = c.String(maxLength: 19),
                        Statue = c.Int(nullable: false),
                        Title = c.String(maxLength: 200),
                        Keyword = c.String(maxLength: 200),
                        Summary = c.String(maxLength: 500),
                        Content = c.String(),
                        Hit = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        PublishTime = c.DateTime(nullable: false),
                        Writer_Id = c.Int(),
                        Brand_Id = c.Int(),
                        ProductType_Id = c.Int(),
                        Industry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegUsers", t => t.Writer_Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductType_Id)
                .ForeignKey("dbo.Industries", t => t.Industry_Id)
                .Index(t => t.Writer_Id)
                .Index(t => t.Brand_Id)
                .Index(t => t.ProductType_Id)
                .Index(t => t.Industry_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.News", new[] { "Industry_Id" });
            DropIndex("dbo.News", new[] { "ProductType_Id" });
            DropIndex("dbo.News", new[] { "Brand_Id" });
            DropIndex("dbo.News", new[] { "Writer_Id" });
            DropForeignKey("dbo.News", "Industry_Id", "dbo.Industries");
            DropForeignKey("dbo.News", "ProductType_Id", "dbo.ProductTypes");
            DropForeignKey("dbo.News", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.News", "Writer_Id", "dbo.RegUsers");
            DropTable("dbo.News");
            DropTable("dbo.Regions");
            DropTable("dbo.ProvinceCities");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Logoes");
            DropTable("dbo.Industries");
            DropTable("dbo.Brands");
            DropTable("dbo.RegUserLogs");
            DropTable("dbo.RegUsers");
        }
    }
}
