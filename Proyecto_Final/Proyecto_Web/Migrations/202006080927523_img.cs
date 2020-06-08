namespace Proyecto_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "ImgUrl", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ImgUrl", c => c.Binary());
            AlterColumn("dbo.Articles", "ImgUrl", c => c.Binary(nullable: false));
        }
    }
}
