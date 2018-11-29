using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PassTheStory.Web.Models;

[assembly: OwinStartupAttribute(typeof(PassTheStory.Web.Startup))]
namespace PassTheStory.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void createRolesandUsers()   
        {   
            ApplicationDbContext context = new ApplicationDbContext();   
   
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));   
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));   
   
            if (!roleManager.RoleExists("Admin"))   
            {   
                var role = new IdentityRole();   
                role.Name = "Admin";   
                roleManager.Create(role);   
      
                var user = new ApplicationUser();   
                user.UserName = "PTSAdmin";   
                user.Email = "ben.musson@gmail.com";   
   
                string userPWD = "gHS9Ydkn8fDw";
   
                var chkUser = UserManager.Create(user, userPWD);   
   
                if (chkUser.Succeeded)   
                {   
                    var result1 = UserManager.AddToRole(user.Id, "Admin");   
   
                }   
            }   
   
            if (!roleManager.RoleExists("User"))   
            {   
                var role = new IdentityRole();   
                role.Name = "User";   
                roleManager.Create(role);   
   
            }
        }
    }
}
