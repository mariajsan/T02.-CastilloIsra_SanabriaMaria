namespace Proyecto_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        Content = c.String(maxLength: 3000),
                        Posted = c.DateTime(nullable: false),
                        ImgUrl = c.String(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comentaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 300),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReaderId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ReaderId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "DateSignUp", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "ReaderId", "dbo.Readers");
            DropForeignKey("dbo.Readers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Comentaries", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comentaries", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Authors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Readers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Favorites", new[] { "ArticleId" });
            DropIndex("dbo.Favorites", new[] { "ReaderId" });
            DropIndex("dbo.Comentaries", new[] { "ArticleId" });
            DropIndex("dbo.Comentaries", new[] { "UserId" });
            DropIndex("dbo.Authors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropColumn("dbo.AspNetUsers", "ImgUrl");
            DropColumn("dbo.AspNetUsers", "DateSignUp");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Readers");
            DropTable("dbo.Favorites");
            DropTable("dbo.Comentaries");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
            DropTable("dbo.Articles");
        }
    }
}
