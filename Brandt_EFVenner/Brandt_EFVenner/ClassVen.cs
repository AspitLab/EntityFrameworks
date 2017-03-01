﻿using System.Collections.Generic;
using System.Data.Entity;

namespace Brandt_EFVenner
{
    public class ClassVen : DbContext
    {
        List<ClassVenTelefonData> venTelefon = new List<ClassVenTelefonData>();
        ClassVenPostData cvpd = new ClassVenPostData();

        public ClassVen()
        {

        }

        public ClassVen(MainVenneTabel inMvt)
        {
            cvpd.strByNavn = inMvt.PostByTabel.byNavn;
            cvpd.intPostNr = inMvt.PostByTabel.postNr;

            foreach (TelefonNr tn in inMvt.TelefonNr)
            {
                ClassVenTelefonData cvtd = new ClassVenTelefonData();
                cvtd.strTelefonNr = tn.telefonNr1.ToString();
                cvtd.strTelefonType = tn.TelefonType.telefonType1.ToString();
                venTelefon.Add(cvtd);
            }
            if (inMvt.TelefonNr.Count <= 0)
            {
                venTelefon.Add(new ClassVenTelefonData());
            }
            venNewTelefon = venTelefon;
        }

        public List<ClassVenTelefonData> venNewTelefon { get; set; }

        public MainVenneTabel venData { get; set; }
    }
}
