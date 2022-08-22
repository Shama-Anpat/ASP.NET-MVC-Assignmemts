﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DFAAssignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MatchEntities : DbContext
    {
        public MatchEntities()
            : base("name=MatchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FootBallLeague> FootBallLeagues { get; set; }
    
        public virtual int spInsertData(Nullable<int> matchId, string teamName1, string teamName2, string matchStatus, string winningTeam, Nullable<int> points)
        {
            var matchIdParameter = matchId.HasValue ?
                new ObjectParameter("MatchId", matchId) :
                new ObjectParameter("MatchId", typeof(int));
    
            var teamName1Parameter = teamName1 != null ?
                new ObjectParameter("TeamName1", teamName1) :
                new ObjectParameter("TeamName1", typeof(string));
    
            var teamName2Parameter = teamName2 != null ?
                new ObjectParameter("TeamName2", teamName2) :
                new ObjectParameter("TeamName2", typeof(string));
    
            var matchStatusParameter = matchStatus != null ?
                new ObjectParameter("MatchStatus", matchStatus) :
                new ObjectParameter("MatchStatus", typeof(string));
    
            var winningTeamParameter = winningTeam != null ?
                new ObjectParameter("WinningTeam", winningTeam) :
                new ObjectParameter("WinningTeam", typeof(string));
    
            var pointsParameter = points.HasValue ?
                new ObjectParameter("Points", points) :
                new ObjectParameter("Points", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertData", matchIdParameter, teamName1Parameter, teamName2Parameter, matchStatusParameter, winningTeamParameter, pointsParameter);
        }
    
        public virtual ObjectResult<spMatachesPlayedByJapan_Result> spMatachesPlayedByJapan()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spMatachesPlayedByJapan_Result>("spMatachesPlayedByJapan");
        }
    
        public virtual ObjectResult<spRetriveStatusAsWin_Result> spRetriveStatusAsWin()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spRetriveStatusAsWin_Result>("spRetriveStatusAsWin");
        }
    
        public virtual ObjectResult<spRetriveWinning_Result> spRetriveWinning()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spRetriveWinning_Result>("spRetriveWinning");
        }
    }
}