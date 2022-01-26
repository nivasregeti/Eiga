namespace Eiga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerBirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerBirthDate");
        }
    }
}
