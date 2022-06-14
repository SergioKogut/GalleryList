using GalleryList.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GalleryList.DAL
{
    public class ApplicationContext : IdentityDbContext<DbUser, DbRole, long, IdentityUserClaim<long>,
    DbUserRole, IdentityUserLogin<long>,
    IdentityRoleClaim<long>, IdentityUserToken<long>>
    {

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            //modelBuilder.Entity<User>().HasData(
            //        new User { Id = 1, Name = "Sergio",Surname="Kohut",Photo="no_photo", Age = 42 },
            //        new User { Id = 2, Name = "Tamara", Surname = "Kohut", Photo = "no_photo", Age = 39 },
            //        new User { Id = 3, Name = "Svitlana", Surname = "Kohut", Photo = "no_photo", Age = 17 },
            //        new User { Id = 4, Name = "Dany", Surname = "Kohut", Photo = "no_photo", Age = 13 }
            //);
        }



    }
}
