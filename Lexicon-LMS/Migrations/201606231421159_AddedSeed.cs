namespace Lexicon_LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Activities", "StartTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Activities", "StartDate");
        }
    }
}
