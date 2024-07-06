using CoreWebApp_2_4.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp_2_4.DataAccess.Repositories
{
    public class PublisherRepository
    {
        public static List<Publisher> publishers;
        public PublisherRepository() { }

        static PublisherRepository()
        {
            publishers = new List<Publisher>();
        }

        public List<Publisher> Publishers
        {
            get
            {
                return publishers;
            }
        }
        public void Save(Publisher publisher)
        {
            //Code to save data in database
            publishers.Add(publisher);
        }
    }
}
