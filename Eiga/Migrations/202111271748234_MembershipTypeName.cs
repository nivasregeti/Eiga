namespace Eiga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipTypeName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipTypeName");
        }
    }
}
