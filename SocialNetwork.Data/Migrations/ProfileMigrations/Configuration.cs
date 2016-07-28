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
                         Username = "Visitante@aranda.com",
                         Address = "Address: Cra. 69 #98 A 11 Piso 7, Bogotá, Cundinamarca",
                         Email = "Visitante@aranda.com",
                         Name = "Aranda Visitante",
                         Password = "password",
                         Phone = "7563000",
                         Subject = "4"
                     },
                     Name = "Visitante",
                     Action = "Lee",
                     Alias = "Visitante",
                     Enabled = true,
                     Secret = "secret",
                     Hierarchy = 4
                 },
                new Profile
                {
                    User = new User
                    {
                        Username = "Autenticado@aranda.com",
                        Address = "Address: Cra. 69 #98 A 11 Piso 7, Bogotá, Cundinamarca",
                        Email = "Autenticado@aranda.com",
                        Name = "Aranda Autenticado",
                        Password = "password",
                        Phone = "7563000",
                        Subject = "3"
                    },
                    Name = "Autenticado",
                    Action = "Comenta",
                    Alias = "Autenticado",
                    Enabled = true,
                    Secret = "secret",
                    Hierarchy = 3
                },
                 new Profile
                 {
                     User = new User
                     {
                         Username = "Editor@aranda.com",
                         Address = "Address: Cra. 69 #98 A 11 Piso 7, Bogotá, Cundinamarca",
                         Email = "Editor@aranda.com",
                         Name = "Aranda Editor",
                         Password = "password",
                         Phone = "7563000",
                         Subject = "2"
                     },
                     Name = "Editor",
                     Action = "Aprueba",
                     Alias = "Editor",
                     Enabled = true,
                     Secret = "secret",
                     Hierarchy = 2
                 },
                 new Profile
                 {
                     User = new User
                     {
                         Username = "Admin@aranda.com",
                         Address = "Address: Cra. 69 #98 A 11 Piso 7, Bogotá, Cundinamarca",
                         Email = "Admin@aranda.com",
                         Name = "Aranda Admin",
                         Password = "password",
                         Phone = "7563000",
                         Subject = "1"
                     },
                     Name = "Admin",
                     Action = "Total",
                     Alias = "Admin",
                     Enabled = true,
                     Secret = "secret",
                     Hierarchy = 1
                 });
        }
    }
}
