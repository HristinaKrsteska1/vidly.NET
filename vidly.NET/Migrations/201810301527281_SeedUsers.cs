namespace vidly.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2440be13-5bfb-44d3-ba66-da2891c56d22', N'admin@vidly.com', 0, N'AGlgF0o1iPE35Vh5AlE6n0Wy8sA+Q9KEF0iIxQki8SbH7/ORJbVbpgfkbwEJ+ONBzw==', N'2e01d03e-8c53-48a9-80e2-b48fd1aab4ff', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'73fb4825-df3d-4797-8111-aa39747819bb', N'guest@vidly.com', 0, N'AFWmDx7H0h1rbuJ/z+VHuHE/u/rPtyunFM/uF494RZLarjNXLPVletiA7koEuqMhQQ==', N'040827e7-4293-453d-9be4-f596d7f29c9d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9e2f6727-6c7f-4ba1-a9d8-cf17ab4bff66', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2440be13-5bfb-44d3-ba66-da2891c56d22', N'9e2f6727-6c7f-4ba1-a9d8-cf17ab4bff66')

");
        }
        
        public override void Down()
        {
        }
    }
}