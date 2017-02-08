namespace ZenithDataLib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new ApplicationDbContext()));

            manager.Create(new ApplicationUser() { UserName = "a", Email = "a@a.a", SecurityRole = "Admin" }, "P@$$w0rd");
            manager.Create(new ApplicationUser() { UserName = "m", Email = "m@m.m", SecurityRole = "Member" }, "P@$$w0rd");

            context.Activities.AddOrUpdate(
                a => a.ActivityId,
                new Activity { ActivityDescription = "Go-Karting", CreationDate = new DateTime(2003, 01, 04) },
                new Activity { ActivityDescription = "Super Smash Bros Melee Tournament", CreationDate = new DateTime(2001, 11, 21) },
                new Activity { ActivityDescription = "Tennis", CreationDate = new DateTime(1990, 03, 12)},
                new Activity { ActivityDescription = "Polo", CreationDate = new DateTime(1976, 12, 12)},
                new Activity { ActivityDescription = "Water Polo", CreationDate = new DateTime(2002, 04, 28) },
                new Activity { ActivityDescription = "Competitive Vaping", CreationDate = new DateTime(2015, 10, 29)}
                );
        }
    }
}
