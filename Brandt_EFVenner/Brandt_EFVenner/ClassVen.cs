using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandt_EFVenner
{
    public class ClassVen : DbContext
    {
        public ClassVen()
        {

        }

        // public DbSet<Object> venData { get; set; }

        public MainVenneTabel venData { get; set; }
        // public string postVen { get; set; }
        // public string FNavn { get; set; }
        // public string ENavn { get; set; }
    }
}
