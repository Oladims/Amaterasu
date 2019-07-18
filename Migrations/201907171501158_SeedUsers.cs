namespace Amaterasu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'363d4fb3-d650-49bd-8a40-883ca3998a6e', N'guest@amaterasu.com', 0, N'AHeeBNSbPwYSiGoGGjMb3p3rBIGTsT40KLLI1TrpEV1hogzWkwW8+gkfO0N1tNFMHw==', N'af42fd4f-1758-41a4-9709-955ba07d61ff', NULL, 0, 0, NULL, 1, 0, N'guest@amaterasu.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'89eeb040-d6f6-429d-9169-879f000b8cc7', N'admin@amaterasu.com', 0, N'AG1IFxxaLjjzLPV5TJA5PvymvgRs5c/NKhRpgoXYfNXc4oW4CLHzSVwiIXKVg4xL9g==', N'05fa0977-56f3-4922-9548-7652ef633983', NULL, 0, 0, NULL, 1, 0, N'admin@amaterasu.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ed84d53f-e890-455d-86ac-7a89430c5e39', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'89eeb040-d6f6-429d-9169-879f000b8cc7', N'ed84d53f-e890-455d-86ac-7a89430c5e39')

");
        }
        
        public override void Down()
        {
        }
    }
}
