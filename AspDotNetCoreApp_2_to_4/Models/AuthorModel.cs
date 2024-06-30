using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreApp_2_to_4.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
    }
}
