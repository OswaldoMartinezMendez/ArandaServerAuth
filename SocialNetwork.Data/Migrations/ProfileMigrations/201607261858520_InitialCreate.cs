namespace SocialNetwork.Data.Migrations.ProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Alias", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Profiles", "Secret", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Profiles", "Enabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "Enabled");
            DropColumn("dbo.Profiles", "Secret");
            DropColumn("dbo.Profiles", "Alias");
        }
    }
}
