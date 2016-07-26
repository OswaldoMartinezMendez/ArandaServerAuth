namespace SocialNetwork.Data.Migrations.ProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Action = c.String(maxLength: 250),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            //CreateTable(
            //    "dbo.Users",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 250),
            //            Address = c.String(nullable: false),
            //            Phone = c.String(nullable: false, maxLength: 250),
            //            Email = c.String(nullable: false),
            //            Subject = c.String(nullable: false, maxLength: 250),
            //            Username = c.String(nullable: false, maxLength: 250),
            //            Password = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "User_Id", "dbo.Users");
            DropIndex("dbo.Profiles", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Profiles");
        }
    }
}
