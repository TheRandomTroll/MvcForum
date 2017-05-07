namespace MvcForum.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MvcForum.Models.EntityModels;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MvcForum.Data.MvcForumContext context)
        {

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            if (!roleStore.Roles.Any(x => x.Name == "User"))
            {
                roleManager.Create(new IdentityRole("User"));
            }
            if (!roleStore.Roles.Any(x => x.Name == "Administrator"))
            {
                roleManager.Create(new IdentityRole("Administrator"));
            }
            if (!context.Users.Any())
            {
                var admin = new User { UserName = "Admin", Email = "admin@gmail.com" };
                userManager.Create(admin, "Destroy1!");
                if (!userManager.IsInRole(admin.Id, "Administrator"))
                {
                    userManager.AddToRole(admin.Id, "Administrator");
                }

                var user1 = new User { UserName = "TheRandomTroll", Email = "mihailgerginov01@gmail.com" };
                var user2 = new User { UserName = "AchkataJo", Email = "jordanov_a4o@gmail.com" };
                var user3 = new User { UserName = "Milky", Email = "milen8b@gmail.com" };
                var user4 = new User { UserName = "Dummy", Email = "dummy@gmail.com" };
                var user5 = new User { UserName = "mepeshomesmash", Email = "pesho@gmail.com" };

                userManager.Create(user1, "Destroy1!");
                userManager.Create(user2, "Destroy1!");
                userManager.Create(user3, "Destroy1!");
                userManager.Create(user4, "Destroy1!");
                userManager.Create(user5, "Destroy1!");

                userManager.AddToRole(user1.Id, "User");
                userManager.AddToRole(user2.Id, "User");
                userManager.AddToRole(user3.Id, "User");
                userManager.AddToRole(user4.Id, "User");
                userManager.AddToRole(user5.Id, "User");
            }
            if (!context.Categories.Any())
            {
                var cat1 = new Category() { Name = "Gardening" };
                var cat2 = new Category() { Name = "Coding" };
                var cat3 = new Category() { Name = "Personal Experience" };
                var cat4 = new Category() { Name = "Lifestyle" };
                context.Categories.AddOrUpdate(cat1, cat2, cat3, cat4);
                context.Posts.AddOrUpdate(
                    new Post()
                        {
                            Author = context.Users.First(x => x.UserName == "TheRandomTroll"),
                            Category = cat2,
                            Topic = "C# ASP.NET Gossip",
                            Content =
                                "This is just a random post for sharing your ideas about your ASP.NET ideas!",
                            CreatedOn = DateTime.UtcNow
                        },
                    new Post()
                        {
                            Author = context.Users.First(x => x.UserName == "mepeshomesmash"),
                            Category = cat3,
                            Topic = "My Personal Story",
                            Content =
                                "So it all just started when I was 5 years old. Shrek was my favorite movie.",
                            CreatedOn = DateTime.UtcNow
                        });
            }
        }
    }
}
