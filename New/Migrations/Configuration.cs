namespace New.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using New.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<New.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(New.Models.ApplicationDbContext context)
        {
            //var kis = new List<KI>
            //{
            //    new KI { Number = 1, UniRegNum = "11", OE = "CTB", Note = "zab"},
            //     new KI { Number = 2, UniRegNum = "12", OE = "CTB", Note = "zab2"},
            //      new KI { Number = 3, UniRegNum = "13", OE = "CTB", Note = "zab3"}

            //};

            //kis.ForEach(k => context.KIs.Add(k));
            //context.SaveChanges();

            //var gnames = new List<GrifName>
            //{
            //    new GrifName { GrifNameId = 1, Name="Sekretno" },
            //    new GrifName { GrifNameId = 2, Name="Poveritelno" },
            //    new GrifName { GrifNameId = 3, Name="Strogo Sekretno" }
            //};

            //gnames.ForEach(gr => context.GrifNames.Add(gr));
            //context.SaveChanges();

            //var laws = new List<Law>
            //{
            //    new Law { LawId = 1, LawName = "ZZKI" },
            //     new Law { LawId = 2, LawName = "PPZZKI" }
            //};

            //laws.ForEach(l => context.Laws.Add(l));
            //context.SaveChanges();

            //var grifs = new List<Grif>
            //{
            //    new Grif { KIId = 1, GrifNameId=1, LawId=1, DateCreated= DateTime.Parse("2011-11-11"), DateExpired= DateTime.Parse ("2012-12-12") },
            //    new Grif { KIId = 1, GrifNameId=2, LawId=1, DateCreated= DateTime.Parse("2013-11-11"), DateExpired= DateTime.Parse ("2014-12-12") },
            //    new Grif { KIId = 2, GrifNameId=1, LawId=1, DateCreated= DateTime.Parse("2015-11-11"), DateExpired= DateTime.Parse ("2016-12-12") },
            //    new Grif { KIId = 3, GrifNameId=2, LawId=1, DateCreated= DateTime.Parse("2011-11-11"), DateExpired= DateTime.Parse ("2012-12-12") },
            //    new Grif { KIId = 3, GrifNameId=3, LawId=1, DateCreated= DateTime.Parse("2010-11-11"), DateExpired= DateTime.Parse ("2017-12-12") }
            //};
            //grifs.ForEach(g => context.Grifs.Add(g));
            //context.SaveChanges();

            ////This method will be called after migrating to the latest version.

            ////You can use the DbSet<T>.AddOrUpdate() helper extension method
            ////to avoid creating duplicate seed data.E.g.

            ////  context.People.AddOrUpdate(
            ////    p => p.FullName,
            ////    new Person { FullName = "Andrew Peters" },
            ////    new Person { FullName = "Brice Lambson" },
            ////    new Person { FullName = "Rowan Miller" }
            ////  );

        }
    }
}
