namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADdedDiscountTypepropertytoDiscountmodelclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discounts", "DiscountTYpe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discounts", "DiscountTYpe");
        }
    }
}
