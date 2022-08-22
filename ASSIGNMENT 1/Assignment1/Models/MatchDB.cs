using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment1.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Assignment1.Models
{
    public class MatchDB
    {

        // Insert Match Details
        public bool AddMatchDetails(FootBallLeague Match)
        {
           using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MatchID",Match.MatchID);
                cmd.Parameters.AddWithValue("@TeamName1", Match.TeamName1);
                cmd.Parameters.AddWithValue("@TeamName2", Match.TeamName2);
                cmd.Parameters.AddWithValue("@MatchStatus", Match.MatchStatus);
                cmd.Parameters.AddWithValue("@WinningTeam", Match.WinningTeam);
                cmd.Parameters.AddWithValue("@Points", Match.Points);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if(i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        //View Match Details
        public List<FootBallLeague> GetMatchDetails()
        {
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString))
            {
                List<FootBallLeague> MatchDetails = new List<FootBallLeague>();
                SqlCommand cmd = new SqlCommand("select * from FootBallLeague",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);

                foreach(DataRow dr in dt.Rows)
                {
                    MatchDetails.Add(
                        new FootBallLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            MatchStatus = Convert.ToString(dr["MatchStatus"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Points = Convert.ToInt32(dr["Points"])
                        }
                    );

                }
                return MatchDetails;

            }
        }

        // Winnning Team Details

        public List<FootBallLeague> WinningTeamDetails()
        {
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString))
            {
                List<FootBallLeague> winninglist = new List<FootBallLeague>();
                SqlCommand cmd = new SqlCommand("spRetriveWinning", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);

                foreach(DataRow dr in dt.Rows)
                {
                    winninglist.Add(
                        new FootBallLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                          
                        });
                }
                return winninglist;

            }
           
        }

        public List<FootBallLeague> JapanMatchDetails()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString))
            {
                List<FootBallLeague> japanlist = new List<FootBallLeague>();
                SqlCommand cmd = new SqlCommand("spMatachesPlayedByJapan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    japanlist.Add(
                        new FootBallLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            MatchStatus = Convert.ToString(dr["MatchStatus"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Points = Convert.ToInt32(dr["Points"])
                        });
                }
                return japanlist;
            }
        }
    }
}