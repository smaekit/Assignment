namespace Consid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCompanies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Companies (Name, OrganisationNumber, Notes) VALUES ('VOLVO', 11337, 'wtf')");
            Sql("INSERT INTO Companies (Name, OrganisationNumber, Notes) VALUES ('Consid', 11336, 'hello')");
            Sql("INSERT INTO Companies (Name, OrganisationNumber, Notes) VALUES ('Evry', 11338, 'cool')");
        }
        
        public override void Down()
        {
        }
    }
}
