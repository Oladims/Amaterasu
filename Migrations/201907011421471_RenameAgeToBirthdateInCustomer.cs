namespace Amaterasu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAgeToBirthdateInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            DropColumn("dbo.Customers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
