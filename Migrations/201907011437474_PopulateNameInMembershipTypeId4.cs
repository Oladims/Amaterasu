namespace Amaterasu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameInMembershipTypeId4 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipType SET Name = 'Annually' WHERE ID= 4");
        }

        public override void Down()
        {
        }
    }
}
