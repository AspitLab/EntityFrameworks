using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace Brandt_EFVenner
{
    public class ClassVen : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<ClassVenTelefonData> venTelefon = new List<ClassVenTelefonData>();
        ClassVenPostData cvpd = new ClassVenPostData();
        VennerEntities ve = new VennerEntities();

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

        public string _fornavn;
        public string _efternavn;
        public string _adresse;
        public string _postNr;
        public string _byNavn;

        #region strNames
        public string fornavn
        {
            get { return _fornavn; }
            set
            {
                if (value != _fornavn)
                {
                    _fornavn = value;
                }
                Notify("fornavn");
            }
        }
        public string efternavn
        {
            get { return _efternavn; }
            set
            {
                if (value != _efternavn)
                {
                    _efternavn = value;
                }
                Notify("efternavn");
            }
        }
        public string adresse
        {
            get { return _adresse; }
            set
            {
                if (value != _adresse)
                {
                    _adresse = value;
                }
                Notify("adresse");
            }
        }
        public string postNr
        {
            get { return _postNr; }
            set
            {
                if (value != _postNr)
                {
                    _postNr = value;
                }
                Notify("postNr");
            }
        }
        public string byNavn
        {
            get { return _byNavn; }
            set
            {
                if (value != _byNavn)
                {
                    _byNavn = value;
                }
                Notify("byNavn");
            }
        }
        #endregion

        public void GetVenData()
        {
            fornavn = venData.fornavn;
            efternavn = venData.efternavn;
            adresse = venData.adresse;
            postNr = venData.postNr.ToString();
            byNavn = venData.PostByTabel.byNavn;
        }

        public void UpdateVen(string strFornavn, string strEfternavn, string strAdresse, int intPostNr, string strByNavn)
        {
            venData.fornavn = strFornavn;
            venData.efternavn = strEfternavn;
            venData.adresse = strAdresse;
            venData.postNr = intPostNr;
            venData.PostByTabel.byNavn = strByNavn;

            ve.Entry(venData).State = EntityState.Modified;
            ve.SaveChanges();
        }

        public void AddFriend(string strAddFornavn, string strAddEfternavn, string strAddAdresse, int intAddPostNr)
        {
            var newFriend = new MainVenneTabel();

            newFriend.fornavn = strAddFornavn;
            newFriend.efternavn = strAddEfternavn;
            newFriend.adresse = strAddAdresse;
            newFriend.postNr = intAddPostNr;

            ve.Entry(newFriend).State = EntityState.Added;
            ve.SaveChanges();
        }

        public void DeleteFriend()
        {
            //var venAlder = venData.Alder;
            //ve.Entry(venAlder).State = EntityState.Deleted;

            //var venFav = venData.Favoritspil;
            //ve.Entry(venFav).State = EntityState.Deleted;

            //var venWeb = venData.Hjemmeside;
            //ve.Entry(venWeb).State = EntityState.Deleted;

            //var venNick = venData.KaldeNavn;
            //ve.Entry(venNick).State = EntityState.Deleted;

            //var venMail = venData.MailAdr;
            //ve.Entry(venMail).State = EntityState.Deleted;

            //var venTlf = venData.TelefonNr;
            //ve.Entry(venTlf).State = EntityState.Deleted;

            //ve.SaveChanges();

            ve.MainVenneTabel.Attach(venData);
            ve.MainVenneTabel.Remove(venData);
            ve.SaveChanges();
        }

        public List<ClassVenTelefonData> venNewTelefon { get; set; }

        public MainVenneTabel venData { get; set; }
        //public Alder venAlder { get; set; }
        //public Favoritspil venFav { get; set; }
        //public Hjemmeside venWeb { get; set; }
        //public KaldeNavn venNick { get; set; }
        //public MailAdr venMail { get; set; }
        //public TelefonNr venTlf { get; set; }

        public void Notify(string propertyName)
        {
            try
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
