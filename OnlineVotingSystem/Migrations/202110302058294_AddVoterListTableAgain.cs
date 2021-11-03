namespace OnlineVotingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVoterListTableAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoterLists",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    VoterId = c.String(nullable: false),
                    UserId = c.String(),
                    ElectionId = c.String(),
                    PresidentCandidateId = c.Int(),
                    VicePresidentCandidateId = c.Int(),
                    VotedTime = c.DateTime(nullable: true),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.VoterLists");
        }
    }
}
