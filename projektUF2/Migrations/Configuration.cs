namespace projektUF2.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<projektUF2.Models.projektUF2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(projektUF2.Models.projektUF2Context context)
        {
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
            context.Kontakts.AddOrUpdate(x => x.Id,
                   new Kontakt { Id = 1, Imie = "Patriko", Nazwisko = "Fantastico" },
                   new Kontakt { Id = 2, Imie = "Framlp", Nazwisko = "Fantastico" }


                );

        }
    }
}
