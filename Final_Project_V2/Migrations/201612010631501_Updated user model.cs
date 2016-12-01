namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedusermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DisabledCustomer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DisabledEmployee", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "ActiveCustomer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ActiveCustomer", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "DisabledEmployee");
            DropColumn("dbo.AspNetUsers", "DisabledCustomer");
        }
    }
}
