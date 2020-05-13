namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationstoCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "CustomerName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "CustomerName", c => c.String());
        }
    }
}
