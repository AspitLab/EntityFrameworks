using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jens_EFVenner
{
    public class ClassVen : DbContext
    {
        
        
        List<ClassVenTelefonData> venTelefon = new List<ClassVenTelefonData>();

        public ClassVen()
        {

        }

        public ClassVen(MainVenneTabel inMvt)
        {
            foreach (TelefonNr tn in inMvt.TelefonNrs)
            {
                ClassVenTelefonData cvtd = new ClassVenTelefonData();
                cvtd.strTelefonNr = tn.telefonNr1.ToString();
                cvtd.strTelefonType = tn.TelefonType.telefonType1.ToString();
                this.venTelefon.Add(cvtd);               
            }
            if (inMvt.TelefonNrs.Count <= 0)
            {
                this.venTelefon.Add(new ClassVenTelefonData());
            }
            venNewTelefon = venTelefon;
        }
        
        public List<ClassVenTelefonData> venNewTelefon { get; set; }

        public MainVenneTabel venData { get; set; }

    }
}
