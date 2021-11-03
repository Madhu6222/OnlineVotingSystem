using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
    public class VoterList
    {
        public int Id { get; set; }
        [Required]
        public string VoterId { get; set; }
        
        public string userId { get; set; }
        public string ElectionId { get; set; }
        [Display(Name ="President Candidates List")]
        public int PresidentCandidateId { get; set; }
        public int VicePresidentCandidateId { get; set; }
        
        public DateTime? VotedTime { get; set; }
    }
}