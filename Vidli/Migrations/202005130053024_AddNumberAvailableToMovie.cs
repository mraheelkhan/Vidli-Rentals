namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "NumberAvailable", c => c.Int(nullable: false));
            Sql("Update MovieModels Set NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "NumberAvailable");
        }
    }
}
