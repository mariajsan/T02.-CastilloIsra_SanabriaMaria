namespace Proyecto_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class username : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Readers", name: "ApplicationUser_Id", newName: "ReaderId");
            RenameIndex(table: "dbo.Readers", name: "IX_ApplicationUser_Id", newName: "IX_ReaderId");
            DropColumn("dbo.AspNetUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
            RenameIndex(table: "dbo.Readers", name: "IX_ReaderId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Readers", name: "ReaderId", newName: "ApplicationUser_Id");
        }
    }
}
