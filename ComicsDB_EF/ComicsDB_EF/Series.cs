using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsDB_EF
{
    class Series
    {
        public Series()
        {

        }

        public int ID { get; set; }
        public string strPublisher { get; set; }
        public string strUniverse { get; set; }
        public string strSeries { get; set; }
        public int intCollIss { get; set; }
        public int intYear { get; set; }
        public string strComments { get; set; }
        public byte[] bytImage { get; set; }

        public virtual ObservableCollection<Issues> Issues { get; set; }
    }
}
