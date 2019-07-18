namespace Amaterasu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipType SET Name = 'Trial' WHERE ID= 1");
            Sql("UPDATE MembershipType SET Name = 'Monthly' WHERE ID= 2");
            Sql("UPDATE MembershipType SET Name = 'Quarterly' WHERE ID= 3");
            Sql("UPDATE MembershipType SET Name = 'Annually' WHERE ID= 4");
        }   
        
        public override void Down()
        {
        }
    }
}
