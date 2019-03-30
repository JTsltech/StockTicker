namespace Authentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'877cb341-ef49-4b0f-98c9-eeee941d5eff', N'jyotigupta.mitrccse@gmail.com', 0, N'AO9e2MC4ZxxB3qtnYbDga5kNDl4Thrhx+tyQT7aKcJxaWFKxm7Sv9jeirMzgNm0WJg==', N'125e02df-58c2-4ad3-821d-08f5b1e9a3ed', NULL, 0, 0, NULL, 1, 0, N'jyotigupta.mitrccse@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bfaac9e6-7fe5-43e6-af23-58a293d6e88d', N'admin@gmail.com', 0, N'AJPqnyFn1hk7YXsMHEY0QMC9lnSXnB7C9elcrmajY2Zsi8D2bKE/V12Z8cYvx49FMg==', N'3c615ebb-484a-4767-a9e5-37af89c0ed38', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0f50c1ee-c11c-40d2-ad9e-a9671f155dfa', N'TimeManager')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bfaac9e6-7fe5-43e6-af23-58a293d6e88d', N'0f50c1ee-c11c-40d2-ad9e-a9671f155dfa')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
