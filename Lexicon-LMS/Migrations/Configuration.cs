namespace Lexicon_LMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Lexicon_LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    internal sealed class Configuration : DbMigrationsConfiguration<Lexicon_LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lexicon_LMS.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.ActivityTypes.AddOrUpdate(a => a.Name,
                new ActivityType { Name = "E-Learning" },
                new ActivityType { Name = "Övning" },
                new ActivityType { Name = "Föreläsning" },
                new ActivityType { Name = "Inlämningsuppgift" });
            context.SaveChanges();
            context.Courses.AddOrUpdate(c => c.Name,
                new Course { Name = ".Net", Description = ".Net VT 2016", StartDate = new DateTime(2016, 3, 7), EndDate = new DateTime(2016, 7, 15) });
            context.SaveChanges();
            context.Modules.AddOrUpdate(m => m.Name,
               new Module { Name = "C#", Description = "C# programmering Visual Studio", StartDate = new DateTime(2016, 3, 14), EndDate = new DateTime(2016, 4, 15), CourseId = 1 },
               new Module { Name = "MVC", Description = "MVC programmering Visual Studio", StartDate = new DateTime(2016, 6, 14), EndDate = new DateTime(2016, 7, 15), CourseId = 1 },
               new Module { Name = "JavaScript", Description = "Javascript programmering Visual Studio", StartDate = new DateTime(2016, 5, 11), EndDate = new DateTime(2016, 5, 25), CourseId = 1 });
            context.SaveChanges();
            context.Activities.AddOrUpdate(a => a.Name,
                new Activity { Name = "MVC 4 Fundamentals", Description = "MVC 5 Fundamentals with Scott Allen", StartDate = new DateTime(2016, 3, 14), Deadline = new DateTime(2016, 3, 15), ModuleId = 2, ActivityTypeId = 1 },
                new Activity { Name = "MVC 5 Fundamentals", Description = "MVC 5 Fundamentals with Scott Allen", StartDate = new DateTime(2016, 3, 17), Deadline = new DateTime(2016, 3, 18), ModuleId = 2, ActivityTypeId = 1 },
                new Activity { Name = "Övning 16", Description = "Övning 16 MVC", StartDate = new DateTime(2016, 3, 19), Deadline = new DateTime(2016, 3, 20), ModuleId = 2, ActivityTypeId = 2 },
                new Activity { Name = "Föreläsning MVC", Description = "MVC 5 föreläsning med Adrian", StartDate = new DateTime(2016, 3, 21), Deadline = new DateTime(2016, 3, 21), ModuleId = 2, ActivityTypeId = 3 },
                new Activity { Name = "Inlämningsuppgift 11", Description = "Inlämningsuppgift 11", StartDate = new DateTime(2016, 3, 22), Deadline = new DateTime(2016, 3, 25), ModuleId = 2, ActivityTypeId = 4 },
                new Activity { Name = "Föreläsning JavaScript", Description = "Föreläsning JavaScript med Adrian", StartDate = new DateTime(2016, 3, 14), Deadline = new DateTime(2016, 3, 15), ModuleId = 3, ActivityTypeId = 3 },
                new Activity { Name = "Inlämningsuppgift 12", Description = "Inlämningsuppgift 12", StartDate = new DateTime(2016, 7, 1), Deadline = new DateTime(2016, 7, 12), ModuleId = 2, ActivityTypeId = 4 }
                );
            context.SaveChanges();
            //var passwordHash = new PasswordHasher();
            //string password = passwordHash.HashPassword("Demo!123");
            //context.Users.AddOrUpdate(u => u.UserName,
            //    new ApplicationUser { Email = "helenmagnusson@hotmail.com", FirstName = "Helen", LastName = "Magnusson", UserName = "helenmagnusson@hotmail.com", PasswordHash = password });
            //    new ApplicationUser { Email = "teacher@hotmail.com", FirstName = "John", LastName = "Hellman", UserName = "teacher@hotmail.com", PasswordHash = password },
            //   new ApplicationUser { Email = "Pupil@hotmail.com", FirstName = "Johan", LastName = "Haak", UserName = "pupil@hotmail.com", PasswordHash = password });

            //context.SaveChanges();

            if (!context.Roles.Any(r => r.Name == "Pupil"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Pupil" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "pupil@hotmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "pupil@hotmail.com", Email = "Pupil@hotmail.com", FirstName = "Johan", LastName = "Haak", PersonNumber = "921011-1212", PhoneNumber = "07056555563" };

                manager.Create(user, "Demo!123");
                manager.AddToRole(user.Id, "Pupil");
            }
            if (!context.Users.Any(u => u.UserName == "helenmagnusson@hotmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "helenmagnusson@hotmail.com", Email = "helenmagnusson@hotmail.com", FirstName = "Helen", LastName = "Magnusson", PersonNumber = "XXXXXX-XXXX", PhoneNumber = "07056555563" };

                manager.Create(user, "Demo!123");
                manager.AddToRole(user.Id, "Pupil");
            }
            if (!context.Roles.Any(r => r.Name == "Teacher"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Teacher" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "teacher@hotmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "teacher@hotmail.com", Email = "teacher@hotmail.com", FirstName = "John", LastName = "Hellman", PersonNumber = "XXXXXX-XXXX", PhoneNumber = "07056555563" };

                manager.Create(user, "Demo!123");
                manager.AddToRole(user.Id, "Teacher");
            }
            if (!context.Documents.Any(d => d.FileName == "Övning11_Helen"))
            {
                context.Documents.AddOrUpdate(d => d.FileName,
                new Document { FileName = "Övning11_Helen", Description = "Helens inlämningsuppgift 11", ActivityId = 5, UserId = (context.Users.FirstOrDefault(u => u.UserName == "helenmagnusson@hotmail.com").Id), Path = "c:/Documents", Created = new DateTime(2016, 6, 12) });
            }
            if (!context.Documents.Any(d => d.FileName == "Övning12_Helen"))
            {
                context.Documents.AddOrUpdate(d => d.FileName,
                new Document { FileName = "Övning12_Helen", Description = "Helens inlämningsuppgift 12", ActivityId = 7, UserId = (context.Users.FirstOrDefault(u => u.UserName == "helenmagnusson@hotmail.com").Id), Path = "c:/Documents", Created = new DateTime(2016, 6, 27) });
            }
            context.SaveChanges();

        }
    }
}
