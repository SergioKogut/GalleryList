using GalleryList.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace GalleryList.DAL.Seeder
{
    public class SeederDB
    {
        public static void SeedUsers(UserManager<DbUser> userManager,
           RoleManager<DbRole> roleManager)
        {
            var roleName1 = "Admin";
            if (roleManager.FindByNameAsync(roleName1).Result == null)
            {
                var result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName1
                }).Result;
            }

            var roleName2 = "User";
            if (roleManager.FindByNameAsync(roleName2).Result == null)
            {
                var result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName2
                }).Result;
            }

            var email1 = "admin@gmail.com";
            if (userManager.FindByEmailAsync(email1).Result == null)
            {
                var user = new DbUser
                {
                    FirstName = "Vasyl",
                    MiddleName = "Vasylyovych",
                    LastName = "Vasylyuk",
                    DateOfBirth = DateTime.Now,
                    AvatarUrl = "no_image.jpg",
                    Email = email1,
                    UserName = email1,
                    SignUpTime = DateTime.Now,
                };

                var result = userManager.CreateAsync(user, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(user, roleName1).Result;
            }

            var email2 = "user@gmail.com";
            if (userManager.FindByEmailAsync(email2).Result == null)
            {
                var user = new DbUser
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivavovych",
                    LastName = "Ivanenko",
                    DateOfBirth = DateTime.Now,
                    AvatarUrl = "1e55aeb8.jpg",
                    Email = email2,
                    UserName = email2,
                    SignUpTime = DateTime.Now,
                };

                var result = userManager.CreateAsync(user, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(user, roleName2).Result;
            }
        }
        public static void SeedDataByAS(IServiceProvider services, IWebHostEnvironment env,
            IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                SeederDB.SeedUsers(manager, managerRole);
                
            }
        }
    }
}
