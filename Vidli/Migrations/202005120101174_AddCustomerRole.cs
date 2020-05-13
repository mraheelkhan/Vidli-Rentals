namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ( [Id], [Name]) VALUES (N'd2f44e39-e943-4a51-bbdb-b7fa7549944c', N'CanManageCustomers')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a83860c8-39f6-4940-a8b8-70fcbd8cb9f9', N'd2f44e39-e943-4a51-bbdb-b7fa7549944c')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
