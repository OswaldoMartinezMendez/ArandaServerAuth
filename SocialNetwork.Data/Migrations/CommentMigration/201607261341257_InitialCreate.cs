namespace SocialNetwork.Data.Migrations.CommentMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 500),
                        Approved = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 250),
                        Username = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
