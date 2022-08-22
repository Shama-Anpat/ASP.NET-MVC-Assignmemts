using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CFAAssignment1.Models
{
    public class FootBallLeagueContext : DbContext //this class will store the data into database
    {
        public DbSet<FootBallLeague> FootBallLeagues { get; set; } 
    }
}