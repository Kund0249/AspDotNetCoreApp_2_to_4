using CoreWebApp_2_4.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp_2_4.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
