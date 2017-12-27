namespace Spark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "FriendId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FriendId");
            DropColumn("dbo.Users", "EventId");
            DropColumn("dbo.Users", "Name");
        }
    }
}
