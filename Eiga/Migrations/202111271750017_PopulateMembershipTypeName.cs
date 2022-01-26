namespace Eiga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Pay as you go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Yearly' WHERE Id = 4");

        }

        public override void Down()
        {
        }
    }
}
