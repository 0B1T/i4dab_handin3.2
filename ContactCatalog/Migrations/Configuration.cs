using ContactCatalog.Models;
using System.Data.Entity.Migrations;

namespace ContactCatalog.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ContactCatalog.Models.ContactCatalogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactCatalog.Models.ContactCatalogContext context)
        {
            context.People.AddOrUpdate(p => p.PersonID,
                new Person()
                {
                    PersonID = 1,
                    FirstName = "John",
                    MiddleName = "Romby",
                    LastName = "Andersson",
                    PersonType = "Private"
                });
            context.People.AddOrUpdate(p => p.PersonID,
                new Person()
                {
                    PersonID = 2,
                    FirstName = "Maya",
                    MiddleName = "Romby",
                    LastName = "Andersson",
                    PersonType = "Private"
                });
            context.People.AddOrUpdate(p => p.PersonID,
                new Person()
                {
                    PersonID = 3,
                    FirstName = "Gry",
                    MiddleName = "Romby",
                    LastName = "Andersson",
                    PersonType = "Private"
                });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
