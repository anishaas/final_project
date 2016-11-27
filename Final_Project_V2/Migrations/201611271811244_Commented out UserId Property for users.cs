namespace Final_Project_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentedoutUserIdPropertyforusers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserID", c => c.String());
        }
    }
}
