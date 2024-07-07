using CoreWebApp_2_4.DataAccess.Entities;
using System;
using CoreWebApp_2_4.DataAccess.Utilities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace CoreWebApp_2_4.DataAccess.Repositories
{
    public class PublisherRepository
    {
        public static List<Publisher> publishers;
        private string CS;
        public PublisherRepository()
        {
            CS = "data source=DESKTOP-G3RV5V6;database=CoreWebApp_2_4_DB;TrustServerCertificate=True;trusted_connection=true";
        }

        static PublisherRepository()
        {
            publishers = new List<Publisher>();
        }

        public List<Publisher> Publishers
        {
            get
            {
                List<Publisher> publishersList = new List<Publisher>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(spNames.GetPublisers, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            publishersList.Add(new Publisher()
                            {
                                PublisherName = Convert.ToString(reader["publisherName"]),
                                EmailAddress = Convert.ToString(reader["emailAddress"]),
                                ContactNo = Convert.ToString(reader["contactNumber"])

                            });
                        }
                        con.Close();
                    }
                }
                return publishersList;
            }
        }
        public void Save(Publisher publisher)
        {
            //Code to save data in database
            //publishers.Add(publisher);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(spNames.AddPubliser, con);

                //
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@publisherName", publisher.PublisherName);
                cmd.Parameters.AddWithValue("@emailAddress", publisher.EmailAddress);
                cmd.Parameters.AddWithValue("@contactNumber", publisher.ContactNo);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
            }
        }
    }
}
