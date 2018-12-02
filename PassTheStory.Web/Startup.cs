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
                    var result = UserManager.AddToRole(user.Id, "Admin");   
                }
            }   
   
            if (!roleManager.RoleExists("User"))   
            {   
                var role = new IdentityRole();   
                role.Name = "User";   
                roleManager.Create(role);   
                
                var user1 = new ApplicationUser();   
                user1.UserName = "TheSonAlsoWrites";   
                user1.Email = "ben.musson@gmail.com";   
   
                string userPWD = "gHS9Ydkn8fDw";
   
                var chkUser = UserManager.Create(user1, userPWD);   
   
                if (chkUser.Succeeded)   
                {   
                    var result = UserManager.AddToRole(user1.Id, "User");   
                }

                var user2 = new ApplicationUser();   
                user2.UserName = "MobyRichard";   
                user2.Email = "ben.musson@gmail.com";   
      
                var chkUser2 = UserManager.Create(user1, userPWD);   
   
                if (chkUser2.Succeeded)   
                {   
                    var result = UserManager.AddToRole(user2.Id, "User");   
                }

                var user3 = new ApplicationUser();   
                user3.UserName = "WineDarkSailor";   
                user3.Email = "ben.musson@gmail.com";   
   
                var chkUser3 = UserManager.Create(user3, userPWD);   
   
                if (chkUser3.Succeeded)   
                {   
                    var result = UserManager.AddToRole(user3.Id, "User");   
                }

                var user4 = new ApplicationUser();   
                user4.UserName = "TheGreaterGatsby";   
                user4.Email = "ben.musson@gmail.com";   
      
                var chkUser4 = UserManager.Create(user4, userPWD);   
   
                if (chkUser4.Succeeded)   
                {   
                    var result = UserManager.AddToRole(user4.Id, "User");   
                }

                var user5 = new ApplicationUser();   
                user5.UserName = "PrideAndUnprejudiced";   
                user5.Email = "ben.musson@gmail.com";   
      
                var chkUser5 = UserManager.Create(user5, userPWD);   
   
                if (chkUser5.Succeeded)   
                {   
                    var result = UserManager.AddToRole(user5.Id, "User");   
                }

                var user6 = new ApplicationUser();   
                user6.UserName = "TheScarletWriter";   
                user6.Email = "ben.musson@gmail.com";   
      
                var chkUser6 = UserManager.Create(user6, userPWD);   
   
                if (chkUser6.Succeeded)   
                {   
                    var result = UserManager.AddToRole(user6.Id, "User");   
                }
            }
        }
    }
}
