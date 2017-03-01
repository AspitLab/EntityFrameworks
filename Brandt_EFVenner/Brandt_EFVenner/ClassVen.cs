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
        List<ClassVenTelefonData> venTelefon = new List<ClassVenTelefonData>();
        List<ClassVenPostData> venPostNr = new List<ClassVenPostData>();

        public ClassVen()
        {

        }

        public ClassVen(MainVenneTabel inMvt)
        {
            foreach (TelefonNr tn in inMvt.TelefonNr)
            {
                ClassVenTelefonData cvtd = new ClassVenTelefonData();
                cvtd.strTelefonNr = tn.telefonNr1.ToString();
                cvtd.strTelefonType = tn.TelefonType.telefonType1.ToString();
                this.venTelefon.Add(cvtd);
            }
            if (inMvt.TelefonNr.Count <= 0)
            {
                this.venTelefon.Add(new ClassVenTelefonData());
            }
            venNewTelefon = venTelefon;

            //foreach (PostByTabel pbt in inMvt.PostByTabel)
            //{
            //    ClassVenPostData cvpd = new ClassVenPostData();
            //    cvpd.strByNavn = pbt.byNavn.ToString();
            //    cvpd.strPostNr = pbt.postNr.ToString();
            //    this.venPostNr.Add(cvpd);
            //}
            //if (inMvt.PostByTabel.Count <= 0)
            //{
            //    this.venPostNr.Add(new ClassVenPostData());
            //}
        }

        public List<ClassVenTelefonData> venNewTelefon { get; set; }

        public List<ClassVenPostData> venNewPostNr { get; set; }

        public MainVenneTabel venData { get; set; }
    }
}
