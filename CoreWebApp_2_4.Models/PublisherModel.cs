using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreWebApp_2_4.DataAccess.Entities;

namespace CoreWebApp_2_4.Models
{
    public class PublisherModel
    {
        public string PublisherName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; } 

        public static PublisherModel Convert(Publisher publisher)
        {
            return new PublisherModel
            {
                PublisherName = publisher.PublisherName,
                EmailAddress = publisher.EmailAddress,
                ContactNo = publisher.ContactNo
            };
        }
        public static Publisher Convert(PublisherModel publisher)
        {
            return new Publisher
            {
                PublisherName = publisher.PublisherName,
                EmailAddress = publisher.EmailAddress,
                ContactNo = publisher.ContactNo
            };
        }
    }
}
