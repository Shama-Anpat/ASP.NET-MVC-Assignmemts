using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Assignment2.Models
{
    public class BusInfomDB
    {
        public bool Insertbusinfo(BusInfom busdetails)
        {
            using (SqlConnection con = new SqlConnection("data source=.;database= DatabaseFirst ;integrated security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand("spInsertData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BoardingPoint", busdetails.BoardingPoint);
                cmd.Parameters.AddWithValue("@Traveldate", busdetails.TravelDate);
                cmd.Parameters.AddWithValue("@Amount", busdetails.Amount);
                cmd.Parameters.AddWithValue("@Rating", busdetails.Rating);

                SqlParameter outputparameter = new SqlParameter();
                outputparameter.ParameterName = "@BusId";
                outputparameter.SqlDbType = SqlDbType.Int;
                outputparameter.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outputparameter);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                string j = outputparameter.Value.ToString();
                busdetails.BusId = Convert.ToInt32(j);
                if (i >= 1)
                    return true;
                else
                    return false;

            }
        }
        public List<BusInfom> businfos()
        {
            List<BusInfom> buslist = new List<BusInfom>();
            using (SqlConnection con = new SqlConnection("data source=.;database= DatabaseFirst ;integrated security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand("select * from BusInfom", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist.Add(
                        new BusInfom
                        {
                            BusId = Convert.ToInt32(dr["BusId"]),
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            TravelDate = Convert.ToDateTime(dr["TravelDate"]),
                            Amount = Convert.ToDouble(dr["Amount"]),
                            Rating = Convert.ToInt32(dr["Rating"])
                        });

                }
                return buslist;
            }
        }

        public List<BusInfom> businfosbyamount()
        {
            List<BusInfom> buslist = new List<BusInfom>();
            using (SqlConnection con = new SqlConnection("data source=.;database= DatabaseFirst;integrated security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand("spRetriveByAmount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist.Add(
                        new BusInfom
                        {

                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            TravelDate = Convert.ToDateTime(dr["TravelDate"]),
                            Amount = Convert.ToDouble(dr["Amount"]),

                        });

                }
                return buslist;
            }
        }
        public List<BusInfom> businfosbyrating()
        {
            List<BusInfom> buslist = new List<BusInfom>();
            using (SqlConnection con = new SqlConnection("data source=.;database= DatabaseFirst;integrated security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand("spRetriveByRatings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist.Add(
                        new BusInfom
                        {
                            BusId = Convert.ToInt32(dr["BusId"]),
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            Rating = Convert.ToInt32(dr["Rating"])
                        });

                }
                return buslist;
            }
        }
        public List<BusInfom> businfosbydate()
        {
            List<BusInfom> buslist = new List<BusInfom>();
            using (SqlConnection con = new SqlConnection("data source=.;database= DatabaseFirst ;integrated security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand("spRetriveByDate", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist.Add(
                        new BusInfom
                        {
                            BusId = Convert.ToInt32(dr["BusId"]),
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            TravelDate = Convert.ToDateTime(dr["TravelDate"]),

                        });

                }
                return buslist;
            }
        }
        public List<BusInfom> businfosbyboardingpoint()
        {
            List<BusInfom> buslist = new List<BusInfom>();
            using (SqlConnection con = new SqlConnection("data source=.;database= DatabaseFirst ;integrated security=SSPI"))
            {
                SqlCommand cmd = new SqlCommand("spRetriveByBoardingPoint", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist.Add(
                        new BusInfom
                        {
                            BusId = Convert.ToInt32(dr["BusId"]),
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            TravelDate = Convert.ToDateTime(dr["TravelDate"]),
                            Amount = Convert.ToDouble(dr["Amount"]),
                            Rating = Convert.ToInt32(dr["Rating"])
                        });

                }
                return buslist;
            }
        }

    }
}
