namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActiveCustomerbooleantoAppUsermodelclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ActiveCustomer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ActiveCustomer");
        }
    }
}
