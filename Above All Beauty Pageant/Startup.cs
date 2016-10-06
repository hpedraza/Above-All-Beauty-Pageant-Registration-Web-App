using Above_All_Beauty_Pageant.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Above_All_Beauty_Pageant.Startup))]
namespace Above_All_Beauty_Pageant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdmin();
        }

        private void CreateAdmin()
        {
            AboveAllContext context = new AboveAllContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

   
            if (!roleManager.RoleExists("Admin"))
            {

             
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);


                var user = new ApplicationUser("Lilia", "Pedraza", "Admin_LiliaRP@aboveall.com");

                user.Id = Guid.NewGuid().ToString();
                var chkUser = UserManager.Create(user, "Joseph23_");


                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            
            if(!context.Events.Any(x => x.EventName == "Spooktacular Beauty Pageant"))
            {
                var date = new DateTime(2016, 10, 29);

                var Event1 = new Event("Spooktacular Beauty Pageant", date);

                context.Events.Add(Event1);
                context.SaveChanges();

                var eventId = context.Events
                    .FirstOrDefault(e => e.EventName == Event1.EventName).Id;

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


                var eventCategory1 = new EventCategory(cat1, eventId);
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


                context.Categories.Add(eventCategory1);
                context.Categories.Add(eventCategory2);
                context.Categories.Add(eventCategory3);
                context.Categories.Add(eventCategory4);
                context.Categories.Add(eventCategory5);
                context.Categories.Add(eventCategory6);
                context.Categories.Add(eventCategory7);
                context.Categories.Add(eventCategory8);
                context.Categories.Add(eventCategory9);
                context.Categories.Add(eventCategory10);
                context.Categories.Add(eventCategory11);

                context.SaveChanges();
            }
        }
    }


}
