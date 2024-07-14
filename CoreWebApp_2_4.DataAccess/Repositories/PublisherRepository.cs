using CoreWebApp_2_4.DataAccess.Entities;
using System;
using CoreWebApp_2_4.DataAccess.Utilities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using CoreWebApp_2_4.DataAccess.Data;

namespace CoreWebApp_2_4.DataAccess.Repositories
{
    public class PublisherRepository
    {
        //public static List<Publisher> publishers;
        //private string CS;
        //public PublisherRepository()
        //{
        //    CS = "data source=DESKTOP-G3RV5V6;database=BMSDB;TrustServerCertificate=True;trusted_connection=true";
        //}

        public readonly DataContext _dbcontext;

        public PublisherRepository()
        {
            
        }
        public PublisherRepository(DataContext context)
        {
            _dbcontext = context;
        }

        public List<Publisher> Publishers
        {
            get
            {
                return _dbcontext.Publishers.ToList();
            }
        }
        public void Save(Publisher publisher)
        {
            //Code to save data in database
            //publishers.Add(publisher);
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //    SqlCommand cmd = new SqlCommand(spNames.AddPubliser, con);

            //    //
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //    cmd.Parameters.AddWithValue("@publisherName", publisher.PublisherName);
            //    cmd.Parameters.AddWithValue("@emailAddress", publisher.EmailAddress);
            //    cmd.Parameters.AddWithValue("@contactNumber", publisher.ContactNo);
            //    con.Open();
            //    cmd.ExecuteReader();
            //    con.Close();
            //}
            _dbcontext.Publishers.Add(publisher);
            _dbcontext.SaveChanges();
        }
    }
}
