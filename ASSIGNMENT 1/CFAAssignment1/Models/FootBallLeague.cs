using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CFAAssignment1.Models
{
 
    public class FootBallLeague
    {
        [Key]
        public int MatchID { get; set; }
        public string TeamName1 { get; set; }
        public string TeamName2 { get; set; }
        public string MatchStatus { get; set; }
        public string WinningTeam { get; set; }
        public int Points { get; set; }
    }
}