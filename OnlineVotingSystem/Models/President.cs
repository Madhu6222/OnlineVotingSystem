using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
    public class President
    {

        public int Id { get; set; }
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        public int TotalVote { get; set; }
       /* public string ProfilePicPath { get; set; }
        [Required]
        public string SymbolPath { get; set; }*/
    }
}