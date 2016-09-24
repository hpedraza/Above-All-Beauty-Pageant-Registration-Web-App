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
        }
    }


}
