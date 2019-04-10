using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudyCase.UI.Models;

namespace StudyCase.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudyCase.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudyCase.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Roles.Add(new IdentityRole()
            {
                Id = "1",
                Name = "Admin"
            });
            IdentityUserRole identityUserRole = new IdentityUserRole()
            {
                RoleId = "1",
                UserId = "1"
            };
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");
            context.Users.Add(new ApplicationUser()
            {
                Id = "1",
                Email = "admin@studycase.com",
                EmailConfirmed = true,
                Roles = { identityUserRole },
                UserName = "admin@studycase.com",
                PasswordHash = password,
                SecurityStamp = "f317832e-8b19-4b6a-af90-4259121b96d5",
                LockoutEnabled = true
            });


        }
    }
}
