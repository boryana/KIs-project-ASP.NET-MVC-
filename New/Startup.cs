using System;
using Microsoft.Owin;
using Owin;
using New.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;

[assembly: OwinStartupAttribute(typeof(New.Startup))]
namespace New
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
        }

        private void createRoles()
        {
            //ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (!roleManager.RoleExists("Admin"))
            {
                var roleCreateResult = roleManager.Create(new IdentityRole("Admin"));
                if (!roleCreateResult.Succeeded) { throw new Exception(string.Join("; ", roleCreateResult.Errors)); }
                //throw new NotImplementedException();

                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = new ApplicationUser()
                {
                    UserName = "zografov@ki.ko",
                    Email = "zografov@ki.ko"
                };
                var createUserResult = userManager.Create(user, "123456");

                if (!createUserResult.Succeeded) { throw new Exception(string.Join("; ", createUserResult.Errors)); }

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
