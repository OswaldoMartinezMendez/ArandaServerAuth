namespace SocialNetwork.Data.Migrations.UserMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Country_Id", "dbo.Users");
            DropIndex("dbo.Profiles", new[] { "Country_Id" });
            AddColumn("dbo.Users", "Profile_Id", c => c.Int());
            CreateIndex("dbo.Users", "Profile_Id");
            AddForeignKey("dbo.Users", "Profile_Id", "dbo.Profiles", "Id");
            DropColumn("dbo.Profiles", "Country_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Country_Id", c => c.Int());
            DropForeignKey("dbo.Users", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Users", new[] { "Profile_Id" });
            DropColumn("dbo.Users", "Profile_Id");
            CreateIndex("dbo.Profiles", "Country_Id");
            AddForeignKey("dbo.Profiles", "Country_Id", "dbo.Users", "Id");
        }
    }
}
