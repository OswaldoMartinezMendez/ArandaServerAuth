using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.Migrations.ProfileMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialNetwork.Data.DataContext.ProfilesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\ProfileMigrations";
        }

        protected override void Seed(SocialNetwork.Data.DataContext.ProfilesDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Profiles.AddOrUpdate(
                new Profile
                {
                    User = new User
                    {
                        Username = "jose@gmail.com",
                        Address = "Address",
                        Email = "jose@gmail.com",
                        Name = "Jose Mendez",
                        Password = "108888",
                        Phone = "7849796",
                        Subject = "2"
                    },
                    Name = "Visitante",
                    Action = "Read",
                    Alias = "Visitante",
                    Enabled = true,
                    Secret = "secret"
                });
        }
    }
}
