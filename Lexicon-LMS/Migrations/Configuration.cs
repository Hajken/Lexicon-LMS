namespace Lexicon_LMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Lexicon_LMS.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<Lexicon_LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lexicon_LMS.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.ActivityTypes.AddOrUpdate(a => a.ActivityTypeId,
                new ActivityType { Name = "E-Learning" },
                new ActivityType { Name = "Övning" },
                new ActivityType { Name = "Föreläsning" },
                new ActivityType { Name = "Inlämningsuppgift" });
            context.SaveChanges();
            context.Courses.AddOrUpdate(c => c.CourseId,
                new Course { Name = ".Net", Description = ".Net VT 2016", StartDate = new DateTime(2016, 3, 7), EndDate = new DateTime(2016, 7, 15) });
            context.SaveChanges();
            context.Modules.AddOrUpdate(m => m.ModuleId,
               new Module { Name = "C#", Description = "C# programmering Visual Studio", StartDate = new DateTime(2016, 3, 14), EndDate = new DateTime(2016, 4, 15), CourseId = 1 },
               new Module { Name = "MVC", Description = "MVC programmering Visual Studio", StartDate = new DateTime(2016, 6, 14), EndDate = new DateTime(2016, 7, 15), CourseId = 1 },
               new Module { Name = "JavaScript", Description = "Javascript programmering Visual Studio", StartDate = new DateTime(2016, 5, 11), EndDate = new DateTime(2016, 5, 25), CourseId = 1 });
            context.SaveChanges();
            context.Activities.AddOrUpdate(a => a.ActivityId,
                new Activity { Name = "MVC 4 Fundamentals", Description = "MVC 5 Fundamentals with Scott Allen", StartDate = new DateTime(2016, 3, 14), Deadline = new DateTime(2016, 3, 15), ModuleId = 2, ActivityTypeId = 1 },
                new Activity { Name = "MVC 5 Fundamentals", Description = "MVC 5 Fundamentals with Scott Allen", StartDate = new DateTime(2016, 3, 17), Deadline = new DateTime(2016, 3, 18), ModuleId = 2, ActivityTypeId = 1 },
                new Activity { Name = "Övning 16", Description = "Övning 16 MVC", StartDate = new DateTime(2016, 3, 19), Deadline = new DateTime(2016, 3, 20), ModuleId = 2, ActivityTypeId = 2 },
                new Activity { Name = "Föreläsning MVC", Description = "MVC 5 föreläsning med Adrian", StartDate = new DateTime(2016, 3, 21), Deadline = new DateTime(2016, 3, 21), ModuleId = 2, ActivityTypeId = 3 },
                new Activity { Name = "Inlämningsuppgift 11", Description = "Inlämningsuppgift 11", StartDate = new DateTime(2016, 3, 22), Deadline = new DateTime(2016, 3, 25), ModuleId = 2, ActivityTypeId = 4 },
                new Activity { Name = "Föreläsning JavaScript", Description = "Föreläsning JavaScript med Adrian", StartDate = new DateTime(2016, 3, 14), Deadline = new DateTime(2016, 3, 15), ModuleId = 3, ActivityTypeId = 3 },
                new Activity { Name = "Inlämningsuppgift 12", Description = "Inlämningsuppgift 12", StartDate = new DateTime(2016, 7, 1), Deadline = new DateTime(2016, 7, 12), ModuleId = 2, ActivityTypeId = 4 }
                );
            context.SaveChanges();
            context.Documents.AddOrUpdate(d => d.DocumentId,
                new Document { FileName = "Övning11_Helen", Description = "Helens inlämningsuppgift 11", CourseId = 1, ModuleId = 2, UserId = "071ebae0-2d61-4bd3-ba6a-7286326b5c83", Path = "c:/Documents", Created = new DateTime(2016, 6, 12), ActivityId = 5 });
            context.SaveChanges();

        }
    }
}
