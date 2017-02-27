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

            string strSqlLarge = "SELECT MainVenneTabel.id, MainVenneTabel.fornavn, MainVenneTabel.efternavn, " +
                                    "MainVenneTabel.adresse, MainVenneTabel.postNr, PostByTabel.byNavn, TelefonNr.telefonNr, " +
                                    "TelefonType.telefonType, MailAdr.mailAdr, MailType.mailType, KaldeNavn.kaldenavn, " +
                                    "KaldenavnType.kaldenavnType, Favoritspil.spil, Hjemmeside.hjemmeside, Alder.foedselsdato " +
                                    "FROM KaldenavnType RIGHT OUTER JOIN " +
                                    "KaldeNavn ON KaldenavnType.id = KaldeNavn.type RIGHT OUTER JOIN " +
                                    "MainVenneTabel LEFT OUTER JOIN " +
                                    "MailType RIGHT OUTER JOIN " +
                                    "MailAdr ON MailType.id = MailAdr.type " +
                                    "ON MainVenneTabel.id = MailAdr.venId " +
                                    "ON KaldeNavn.venId = MainVenneTabel.id LEFT OUTER JOIN " +
                                    "Favoritspil ON MainVenneTabel.id = Favoritspil.venId LEFT OUTER JOIN " +
                                    "PostByTabel ON MainVenneTabel.postNr = PostByTabel.postNr LEFT OUTER JOIN " +
                                    "TelefonType RIGHT OUTER JOIN " +
                                    "TelefonNr ON TelefonType.id = TelefonNr.type " +
                                    "ON MainVenneTabel.id = TelefonNr.venId LEFT OUTER JOIN " +
                                    "Alder ON MainVenneTabel.id = Alder.venId LEFT OUTER JOIN " +
                                    "Hjemmeside ON MainVenneTabel.id = Hjemmeside.venId";

            using (var ctx = new VennerEntities())
            {
                var minVen = ctx.MainVenneTabels.SqlQuery(strSql);
                foreach (MainVenneTabel i in minVen)
                {
                    ClassVen cv = new ClassVen();
                    cv.venData = i;
                    //MessageBox.Show(i.PostByTabel.byNavn);
                    var Q = i.PostByTabel.byNavn;
                    var x = i.TelefonNrs;
                    //var z = i.TelefonNrs.
                    Ven.Add(cv);

                    //var x = i.TelefonNrs;
                    //foreach (TelefonNr t in x)
                    //{
                    //    var q = t.TelefonType;
                    //    foreach(TelefonType tt in q)
                    //    {
                    //        MessageBox.Show(t.telefonNr1.ToString() + " - " + t.TelefonType.ToString());
                    //    }
                        
                    //}

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
