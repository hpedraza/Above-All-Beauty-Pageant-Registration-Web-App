namespace Above_All_Beauty_Pageant.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<AboveAllContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(AboveAllContext context)
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
            /*
            var Event1Location = new Address
            {
                City = "McAllen",
                ZipCode = 78501,
                State = "TX",
                Street = "700 Convention Center Blvd."
            };

            context.Addresses.AddOrUpdate(a => a.Id, Event1Location);
            context.SaveChanges();
                        */
 
            var date = new DateTime(2016, 10, 29);
            var Event1 = new Event("Spooktacular Beauty Pageant", 10, date);

            context.Events.AddOrUpdate(x => x.EventName,Event1);
            context.SaveChanges();

            var eventId = context.Events
                .FirstOrDefault( e => e.EventName == Event1.EventName).Id;

            AgeGroup cat1 = AgeGroup.BabyMiss;
            AgeGroup cat2 = AgeGroup.BabyMr;
            AgeGroup cat3 = AgeGroup.LittleMiss;
            AgeGroup cat4 = AgeGroup.LittleMr;
            AgeGroup cat5 = AgeGroup.PeeWeeMiss;
            AgeGroup cat6 = AgeGroup.PeeWeeMr;
            AgeGroup cat7 = AgeGroup.PetiteMiss;
            AgeGroup cat8 = AgeGroup.TeenMiss;
            AgeGroup cat9 = AgeGroup.TinyMiss;
            AgeGroup cat10 = AgeGroup.TinyMr;
            AgeGroup cat11 = AgeGroup.YouthMiss;


            var eventCategory1 = new EventCategory(cat1 , eventId);
            var eventCategory2 = new EventCategory(cat2, eventId);
            var eventCategory3 = new EventCategory(cat3, eventId);
            var eventCategory4 = new EventCategory(cat4, eventId);
            var eventCategory5 = new EventCategory(cat5, eventId);
            var eventCategory6 = new EventCategory(cat6, eventId);
            var eventCategory7 = new EventCategory(cat7, eventId);
            var eventCategory8 = new EventCategory(cat8, eventId);
            var eventCategory9 = new EventCategory(cat9, eventId);
            var eventCategory10 = new EventCategory(cat10, eventId);
            var eventCategory11 = new EventCategory(cat11, eventId);


            context.Categories.AddOrUpdate<EventCategory>(eventCategory1);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory2);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory3);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory4);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory5);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory6);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory7);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory8);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory9);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory10);
            context.Categories.AddOrUpdate<EventCategory>(eventCategory11);

            context.SaveChanges();

        }
    }
}
