namespace Consid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToStores : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Stores", "CompanyId");
            AddForeignKey("dbo.Stores", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Stores", new[] { "CompanyId" });
        }
    }
}
