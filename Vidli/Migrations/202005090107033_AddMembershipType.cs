namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CustomerModels", "MemberShipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.CustomerModels", "MemberShipTypeId");
            AddForeignKey("dbo.CustomerModels", "MemberShipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerModels", "MemberShipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.CustomerModels", new[] { "MemberShipTypeId" });
            DropColumn("dbo.CustomerModels", "MemberShipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
