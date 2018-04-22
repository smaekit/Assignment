namespace Consid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStores : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Stores (CompanyId, Name, Adress, City, Zip, Country) VALUES (1,'Volvoklubben','Hamngatan', 'Ume�','90435','Sweden')");
            Sql("INSERT INTO Stores (CompanyId, Name, Adress, City, Zip, Country) VALUES (1,'VolvoStore','Sk�vdegatan', 'Sk�vde','77435','Sweden')");
            Sql("INSERT INTO Stores (CompanyId, Name, Adress, City, Zip, Country) VALUES (2,'HQ','Apotekargr�nd', 'J�nk�ping','55320','Sweden')");
            Sql("INSERT INTO Stores (CompanyId, Name, Adress, City, Zip, Country) VALUES (3,'EvryStore','Hung Hom', 'Kwooloon','117422','Hongkong')");
        }
        
        public override void Down()
        {
        }
    }
}
