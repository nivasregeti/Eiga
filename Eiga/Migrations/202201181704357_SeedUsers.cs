namespace Eiga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'01711183-5c6d-43c6-9319-6540988c843f', N'admin@gmail.com', 0, N'AHb0pKlNdxINP7lre/4uecShFjtTKXWzMEJKxM7tfPcl4l3P3/fvX9jzJmt/CPeedw==', N'86636983-cafc-4e5b-91d7-9ced4b597089', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dbf6ef18-7914-4742-aea7-1118060b29e8', N'nivasregeti@yahoo.com', 0, N'AHwqFTnzk0U/jZJmzT/Q2Vw/yQU2FUsBEFtuXW3LX7QF8BazK+HwKWyRPa68xa3cjg==', N'44876083-9d5f-404d-bb5a-2fe8e84db382', NULL, 0, 0, NULL, 1, 0, N'nivasregeti@yahoo.com')
        INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f4aa7555-2c4f-4ec1-9b2e-866bbdeeb1b9', N'CanManageMovies')
        INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'01711183-5c6d-43c6-9319-6540988c843f', N'f4aa7555-2c4f-4ec1-9b2e-866bbdeeb1b9')
        ");
        }
        
        public override void Down()
        {
        }
    }
}
