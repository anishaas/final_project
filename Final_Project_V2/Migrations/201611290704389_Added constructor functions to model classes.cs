namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedconstructorfunctionstomodelclasses : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Discounts", "DiscountTimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discounts", "DiscountTimeStamp", c => c.DateTime(nullable: false));
        }
    }
}
