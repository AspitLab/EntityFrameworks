using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First_Tutorials
{
    
        public class SchoolContext : DbContext
        {
            public SchoolContext() : base("SchoolTest")
            {

            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Standard> Standards { get; set; }

        }


    

}
