using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsDB_EF
{
    class ComicsContext : DbContext
    {
        public ComicsContext(): base()
        {

        }

        public DbSet<Series> Series { get; set; }
        public DbSet<Issues> Issues { get; set; }
    }
}
