namespace ContactCatalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Addresses = c.Int(nullable: false, identity: true),
                        AddressType = c.String(nullable: false),
                        Streetname = c.String(nullable: false),
                        PostCode_PostCodeId = c.String(nullable: false, maxLength: 128),
                        HousNr = c.String(nullable: false),
                        City_PostCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Addresses)
                .ForeignKey("dbo.Cities", t => t.City_PostCode)
                .Index(t => t.City_PostCode);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        PostCode = c.String(nullable: false, maxLength: 128),
                        CityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PostCode);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        PersonType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.EmailAddrs",
                c => new
                    {
                        Emails = c.String(nullable: false, maxLength: 128),
                        EmailAddrType = c.String(nullable: false),
                        Contact_PersonId = c.Int(nullable: false),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.Emails)
                .ForeignKey("dbo.People", t => t.Person_PersonID)
                .Index(t => t.Person_PersonID);
            
            CreateTable(
                "dbo.PersonAddresses",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        Address_Addresses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.Address_Addresses })
                .ForeignKey("dbo.People", t => t.Person_PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_Addresses, cascadeDelete: true)
                .Index(t => t.Person_PersonID)
                .Index(t => t.Address_Addresses);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailAddrs", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.PersonAddresses", "Address_Addresses", "dbo.Addresses");
            DropForeignKey("dbo.PersonAddresses", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.Addresses", "City_PostCode", "dbo.Cities");
            DropIndex("dbo.PersonAddresses", new[] { "Address_Addresses" });
            DropIndex("dbo.PersonAddresses", new[] { "Person_PersonID" });
            DropIndex("dbo.EmailAddrs", new[] { "Person_PersonID" });
            DropIndex("dbo.Addresses", new[] { "City_PostCode" });
            DropTable("dbo.PersonAddresses");
            DropTable("dbo.EmailAddrs");
            DropTable("dbo.People");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
        }
    }
}
