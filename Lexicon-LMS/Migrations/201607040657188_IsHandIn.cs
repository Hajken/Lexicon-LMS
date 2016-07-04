namespace Lexicon_LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsHandIn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "IsHandIn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "IsHandIn");
        }
    }
}
