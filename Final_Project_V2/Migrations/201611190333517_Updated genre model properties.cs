namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedgenremodelproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "GenreName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "GenreName");
        }
    }
}
