namespace Amaterasu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotationToMembershipType : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MembershipTypes", newName: "MembershipType");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MembershipType", newName: "MembershipTypes");
        }
    }
}
