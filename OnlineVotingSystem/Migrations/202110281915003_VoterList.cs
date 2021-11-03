namespace OnlineVotingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoterList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VoterLists", "VoterId", c => c.String(nullable: false));
            AddColumn("dbo.VoterLists", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.VoterLists", "ElectionId", c => c.String());
            AddColumn("dbo.VoterLists", "PresidentCandidateId", c => c.Int(nullable: false));
            AddColumn("dbo.VoterLists", "VicePresidentCandidateId", c => c.Int(nullable: false));
            AddColumn("dbo.VoterLists", "VotedTime", c => c.DateTime());
            DropColumn("dbo.VoterLists", "Name");
            DropColumn("dbo.VoterLists", "Email");
            DropColumn("dbo.VoterLists", "IsVotedChairman");
            DropColumn("dbo.VoterLists", "IsVotedMemberMan");
            DropColumn("dbo.VoterLists", "IvotedMemberWomen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VoterLists", "IvotedMemberWomen", c => c.Boolean(nullable: false));
            AddColumn("dbo.VoterLists", "IsVotedMemberMan", c => c.Boolean(nullable: false));
            AddColumn("dbo.VoterLists", "IsVotedChairman", c => c.Boolean(nullable: false));
            AddColumn("dbo.VoterLists", "Email", c => c.String());
            AddColumn("dbo.VoterLists", "Name", c => c.String());
            DropColumn("dbo.VoterLists", "VotedTime");
            DropColumn("dbo.VoterLists", "VicePresidentCandidateId");
            DropColumn("dbo.VoterLists", "PresidentCandidateId");
            DropColumn("dbo.VoterLists", "ElectionId");
            DropColumn("dbo.VoterLists", "userId");
            DropColumn("dbo.VoterLists", "VoterId");
        }
    }
}
