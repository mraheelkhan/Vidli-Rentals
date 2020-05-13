namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelRequiredProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "CustomerAddress", c => c.String(nullable: false));
            AlterColumn("dbo.MovieModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MovieModels", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MovieModels", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieModels", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.MovieModels", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.MovieModels", "Name", c => c.String());
            AlterColumn("dbo.CustomerModels", "CustomerAddress", c => c.String());
        }
    }
}
