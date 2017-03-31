using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsDB_EF
{
    class Issues
    {
        public Issues()
        {

        }

        public int ID { get; set; }
        public int SeriesID { get; set; }
        public string strSeries { get; set; }
        public int intNumber { get; set; }
        public string strWriter { get; set; }
        public string strPenciller { get; set; }
        public string strFormat { get; set; }
        public string strLanguage { get; set; }
        public DateTime? dtDate { get; set; }
        public string strComments { get; set; }
        public byte[] bytImage { get; set; }

        public virtual Series Series { get; set; }
    }
}
