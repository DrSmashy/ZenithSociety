namespace ZenithSociety.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        private void addRoles(ZenithDataLib.Models.ApplicationDbContext context) {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin")) {
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Member")) {
                var role = new IdentityRole { Name = "Member" };
                roleManager.Create(role);
            }

            context.SaveChanges();

        }

        private void addEmployees(ZenithDataLib.Models.ApplicationDbContext context) {
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new ApplicationDbContext()));

            if (!context.Users.Any(a => a.UserName == "a")) {
                manager.Create(new ApplicationUser() { UserName = "a", Email = "a@a.a", SecurityRole = "Admin" }, "P@$$w0rd");
                manager.Create(new ApplicationUser() { UserName = "m", Email = "m@m.m", SecurityRole = "Member" }, "P@$$w0rd");
                context.SaveChanges();
                manager.AddToRole(context.Users.Where(u => u.UserName == "a").FirstOrDefault().Id, "Admin");
                manager.AddToRole(context.Users.Where(u => u.UserName == "m").FirstOrDefault().Id, "Member");
                context.SaveChanges();
            }
        }

        private void addActivites(ZenithDataLib.Models.ApplicationDbContext context) {
            /*context.Database.ExecuteSqlCommand("TRUNCATE TABLE Events");
            context.SaveChanges();
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Activities");
            context.SaveChanges();*/

            if (!context.Activities.Any(a => a.ActivityDescription == "Go-Karting")) {
                IList<Activity> activities = new List<Activity>();

                activities.Add(new Activity { ActivityDescription = "Go-Karting", CreationDate = new DateTime(2003, 01, 04) });
                activities.Add(new Activity { ActivityDescription = "Super Smash Bros Melee Tournament", CreationDate = new DateTime(2001, 11, 21) });
                activities.Add(new Activity { ActivityDescription = "Tennis", CreationDate = new DateTime(1990, 03, 12) });
                activities.Add(new Activity { ActivityDescription = "Polo", CreationDate = new DateTime(1976, 12, 12) });
                activities.Add(new Activity { ActivityDescription = "Water Polo", CreationDate = new DateTime(2002, 04, 28) });
                activities.Add(new Activity { ActivityDescription = "Competitive Vaping", CreationDate = new DateTime(2015, 10, 29) });

                context.Activities.AddOrUpdate(
                    a => a.ActivityId,
                    activities.ToArray()
                );

                context.SaveChanges();
            }
        }

        private void addEvents(ZenithDataLib.Models.ApplicationDbContext context) {
            /*context.Database.ExecuteSqlCommand("TRUNCATE TABLE Events");
            context.SaveChanges();*/

            if (!context.Events.Any(e => e.EventFromDate == new DateTime(2016, 02, 12, 10, 0, 0))) {
                IList<Event> events = new List<Event>();

                events.Add(new Event {
                    EventFromDate = new DateTime(2016, 02, 12, 10, 0, 0),
                    EventToDate = new DateTime(2016, 02, 12, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Go-Karting").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Go-Karting").FirstOrDefault(),
                    CreationDate = new DateTime(2016, 01, 01),
                    IsActive = false
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2016, 04, 14, 11, 0, 0),
                    EventToDate = new DateTime(2016, 04, 14, 13, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Super Smash Bros Melee Tournament").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Super Smash Bros Melee Tournament").FirstOrDefault(),
                    CreationDate = new DateTime(2016, 02, 01),
                    IsActive = false
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2016, 07, 17, 13, 0, 0),
                    EventToDate = new DateTime(2016, 07, 17, 15, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Tennis").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Tennis").FirstOrDefault(),
                    CreationDate = new DateTime(2016, 03, 10),
                    IsActive = false
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 4, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 4, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 5, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 5, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 6, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 6, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 7, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 7, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 8, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 8, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 09, 13, 0, 0),
                    EventToDate = new DateTime(2017, 02, 09, 15, 30, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2016, 12, 22),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 10, 10, 0, 0),
                    EventToDate = new DateTime(2017, 02, 10, 15, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Water Polo").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Water Polo").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 10, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 10, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 11, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 11, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 12, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 12, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 13, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 13, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 14, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 14, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 15, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 15, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 16, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 16, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 17, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 17, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 18, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 18, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                events.Add(new Event {
                    EventFromDate = new DateTime(2017, 02, 19, 15, 0, 0),
                    EventToDate = new DateTime(2017, 02, 19, 18, 0, 0),
                    EnteredByUsername = "a",
                    ActivityId = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault().ActivityId,
                    Activity = context.Activities.Where(x => x.ActivityDescription == "Competitive Vaping").FirstOrDefault(),
                    CreationDate = new DateTime(2017, 01, 11),
                    IsActive = true
                });

                context.Events.AddOrUpdate(
                    e => e.EventId,
                    events.ToArray()
                );

                context.SaveChanges();
            }
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context) {
            addRoles(context);

            addEmployees(context);

            addActivites(context);

            addEvents(context);
        }
    }
}
