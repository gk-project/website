namespace GkwCn.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsfull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "OldId", c => c.String(maxLength: 19, fixedLength: true, unicode: false));
            AlterColumn("dbo.Industries", "OldId", c => c.String(maxLength: 19, fixedLength: true, unicode: false));
            AlterColumn("dbo.Logoes", "OldId", c => c.String(maxLength: 19, fixedLength: true, unicode: false));
            AlterColumn("dbo.ProductTypes", "OldId", c => c.String(maxLength: 19, fixedLength: true, unicode: false));
            AlterColumn("dbo.ProvinceCities", "OldId", c => c.String(maxLength: 19, fixedLength: true, unicode: false));
            AlterColumn("dbo.Regions", "OldId", c => c.String(maxLength: 19, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Regions", "OldId", c => c.String(maxLength: 19));
            AlterColumn("dbo.ProvinceCities", "OldId", c => c.String(maxLength: 19));
            AlterColumn("dbo.ProductTypes", "OldId", c => c.String(maxLength: 19));
            AlterColumn("dbo.Logoes", "OldId", c => c.String(maxLength: 19));
            AlterColumn("dbo.Industries", "OldId", c => c.String(maxLength: 19));
            AlterColumn("dbo.Brands", "OldId", c => c.String(maxLength: 19));
        }
    }
}
