using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Brandt_EFVenner
{
    public class ClassBizz
    {
        ClassVen cv = new ClassVen();
        public ClassBizz()
        {

        }

        public void UpdateListview()
        {
            string strSql = "Select * from MainVenneTabel";

            using (var ctx = new VennerEntities())
            {
                var minVen = ctx.MainVenneTabel.SqlQuery(strSql);
                foreach (MainVenneTabel i in minVen)
                {
                    ClassVen cv = new ClassVen(i);
                    cv.venData = i;
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
