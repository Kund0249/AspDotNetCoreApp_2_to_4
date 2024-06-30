using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCoreApp_2_to_4.DataLayer
{
    public class AuthorEntity
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
    }
}
