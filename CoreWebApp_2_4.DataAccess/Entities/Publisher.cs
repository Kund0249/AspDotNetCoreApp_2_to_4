using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp_2_4.DataAccess.Entities
{
    [Table("TPUBLISHER")]
    public class Publisher
    {

        [Key]
        public int PublisherId { get; set; }

        [Column("Name")]
        public string PublisherName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }

        //public int? Age { get; set; }
    }
}
