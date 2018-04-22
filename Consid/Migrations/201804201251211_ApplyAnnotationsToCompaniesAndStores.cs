namespace Consid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToCompaniesAndStores : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Stores", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Stores", "Adress", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Stores", "City", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Stores", "Zip", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Stores", "Country", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stores", "Longitude", c => c.String(maxLength: 15));
            AlterColumn("dbo.Stores", "Latitude", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Latitude", c => c.String());
            AlterColumn("dbo.Stores", "Longitude", c => c.String());
            AlterColumn("dbo.Stores", "Country", c => c.String());
            AlterColumn("dbo.Stores", "Zip", c => c.String());
            AlterColumn("dbo.Stores", "City", c => c.String());
            AlterColumn("dbo.Stores", "Adress", c => c.String());
            AlterColumn("dbo.Stores", "Name", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String());
        }
    }
}
