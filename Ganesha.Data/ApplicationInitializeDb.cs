using Ganesha.Common.Constants;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ganesha.Data {
    public class ApplicationInitializeDb {
        public static void Seed(ApplicationDbContext context) {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists(RoleName.RoleAdministrator)) {
                roleManager.Create(new IdentityRole(RoleName.RoleAdministrator));

                var userName = "admin@ganeshaformation.fr";
                var password = "P@ssw0rd!";

                var user = userManager.FindByName(userName);
                if (user == null) {
                    user = new ApplicationUser {
                        UserName = userName,
                        Email = userName,
                        EmailConfirmed = true
                    };
                    var userResult = userManager.Create(user, password);
                    if (userResult.Succeeded) {
                        userManager.AddToRole(user.Id, RoleName.RoleAdministrator);
                    }
                }
            }

            if (!roleManager.RoleExists(RoleName.RoleSuperAdministrator)) {
                roleManager.Create(new IdentityRole(RoleName.RoleSuperAdministrator));

                var userName = "supadmin@ganeshaformation.fr";
                var password = "P@ssw0rd!";

                var user = userManager.FindByName(userName);
                if (user == null) {
                    user = new ApplicationUser {
                        UserName = userName,
                        Email = userName,
                        EmailConfirmed = true
                    };
                    var userResult = userManager.Create(user, password);
                    if (userResult.Succeeded) {
                        userManager.AddToRole(user.Id, RoleName.RoleSuperAdministrator);
                    }
                }
            }

            if (!roleManager.RoleExists(RoleName.RoleGuest)) {
                roleManager.Create(new IdentityRole(RoleName.RoleGuest));
            }
        }
    }
}
