using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.Migrations.CommentMigration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialNetwork.Data.DataContext.CommentsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CommentMigration";
        }

        protected override void Seed(SocialNetwork.Data.DataContext.CommentsDb context)
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
            context.Comments.AddOrUpdate(
                  new Comment
                  {
                      User = null,
                      Approved = true,
                      Date = DateTime.Now,
                      Description = "Comentario test",
                      Subject = "Test"
                  }
                );

        }
    }
}
