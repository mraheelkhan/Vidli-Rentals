namespace Vidli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDbUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7aece6c3-fbb5-437e-8338-509ebcbeea0f', N'guest5@vidli.com', 0, N'AIKmTsC74yqFikskpIjTcubxqxoxsSYCzr0OOHPDbWUsQAHE3uipQ8zrw5ifGpWXkQ==', N'04d0bfdf-b0a1-446e-9b8f-0d7f87d9d447', NULL, 0, 0, NULL, 1, 0, N'guest5@vidli.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a83860c8-39f6-4940-a8b8-70fcbd8cb9f9', N'admin@vidli.com', 0, N'AHwbkZPVZEBGjWTSMNKVO9D7WSK6YAIARJJTa5cZ9mTiXTEfewnU2+IoiTno37J8HQ==', N'ff438bf9-7639-40d0-bcae-43dbfd2eb627', NULL, 0, 0, NULL, 1, 0, N'admin@vidli.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fadb8801-684d-440c-8c2f-e26b09d4d845', N'raheel5@gmail.com', 0, N'ACssjEOx9tv884hOjFqnwuP4WaxwsmNNRR5lCIEme9huVPgWSxhboLpYayQrVvSFVw==', N'156f592e-4e1f-40f8-a4e5-848797f3d70d', NULL, 0, 0, NULL, 1, 0, N'raheel5@gmail.com')

                --INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd2f44e39-e943-4a51-bbdb-b7fa7549941a', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a83860c8-39f6-4940-a8b8-70fcbd8cb9f9', N'd2f44e39-e943-4a51-bbdb-b7fa7549941a')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
