namespace OnlineVotingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUserIdRequiredPropInVoterListTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VoterLists", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VoterLists", "userId", c => c.String(nullable: false));
        }
    }
}
