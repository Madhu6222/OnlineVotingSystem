using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models.ViewModels
{
    public class candidatesViewModel
    {
        public IEnumerable<President> PresidentCandidate { get; set; }
        public IEnumerable<VicePresident> VicePresidentCandidate { get; set; }
        public VoterList VoterList { get; set; }
    }
}