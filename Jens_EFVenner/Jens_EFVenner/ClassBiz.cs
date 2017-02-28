using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Jens_EFVenner
{
    class ClassBiz
    {

        public ClassBiz()
        {

        }

        public void UpdateVen()
        {

            string strSql = "Select * from MainVenneTabel";            

            using (var ctx = new VennerEntities())
            {
                var minVen = ctx.MainVenneTabels.SqlQuery(strSql);
                foreach (MainVenneTabel i in minVen)
                {
                    ClassVen cv = new ClassVen(i);
                    cv.venData = i;
                    var Q = i.PostByTabel.byNavn;
                    Ven.Add(cv);
                }
            }
        }

        ObservableCollection<ClassVen> ven = new ObservableCollection<ClassVen>();
        public ObservableCollection<ClassVen> Ven
        {
            get
            {
                return ven;
            }
        }

    }
}
