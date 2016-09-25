namespace MVCsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        Site_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Sites", t => t.Site_Id, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.Site_Id);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        Name = c.String(),
                        Url = c.String(),
                        Theme = c.String(),
                        MenuJson = c.String(),
                        Rating = c.Int(nullable: false),
                        AllowComments = c.Boolean(nullable: false),
                        AllowRating = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Site_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.Site_Id, cascadeDelete: true)
                .Index(t => t.Site_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagSites",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Site_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Site_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sites", t => t.Site_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Site_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Site_Id", "dbo.Sites");
            DropForeignKey("dbo.TagSites", "Site_Id", "dbo.Sites");
            DropForeignKey("dbo.TagSites", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Pages", "Site_Id", "dbo.Sites");
            DropForeignKey("dbo.Sites", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.TagSites", new[] { "Site_Id" });
            DropIndex("dbo.TagSites", new[] { "Tag_Id" });
            DropIndex("dbo.Pages", new[] { "Site_Id" });
            DropIndex("dbo.Sites", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "Site_Id" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropTable("dbo.TagSites");
            DropTable("dbo.Tags");
            DropTable("dbo.Pages");
            DropTable("dbo.Sites");
            DropTable("dbo.Comments");
        }
    }
}
