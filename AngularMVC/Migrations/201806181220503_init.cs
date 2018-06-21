namespace AngularMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.MyImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        ProfilePictureId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.MyImages", t => t.ProfilePictureId, cascadeDelete: true)
                .Index(t => t.ProfilePictureId)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "ProfilePictureId", "dbo.MyImages");
            DropForeignKey("dbo.People", "CountryId", "dbo.Countries");
            DropIndex("dbo.People", new[] { "CountryId" });
            DropIndex("dbo.People", new[] { "ProfilePictureId" });
            DropTable("dbo.People");
            DropTable("dbo.MyImages");
            DropTable("dbo.Countries");
        }
    }
}
