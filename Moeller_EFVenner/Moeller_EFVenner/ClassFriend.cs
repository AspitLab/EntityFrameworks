using System.Collections.Generic;
using System.Data.Entity;

namespace Moeller_EFVenner
{
    public class ClassFriend : DbContext
    {
        List<ClassFriendPhoneData> FriendPhone = new List<ClassFriendPhoneData>();
        ClassFriendMailData cvpd = new ClassFriendMailData();

        public ClassFriend()
        {

        }

        /// <summary>
        /// inserts the stuff from MainVenneTabel into itself, where it can be pulled by bindings
        /// </summary>
        /// <param name="inMvt">This is the MainVenneTabel from the database</param>
        public ClassFriend(MainVenneTabel inMvt)
        {
            cvpd.strCityName = inMvt.PostByTabel.byNavn;
            cvpd.intZipNr = inMvt.PostByTabel.postNr;

            foreach (TelefonNr tn in inMvt.TelefonNrs)
            {
                ClassFriendPhoneData cvtd = new ClassFriendPhoneData();
                cvtd.strPhoneNr = tn.telefonNr1.ToString();
                cvtd.strPhoneType = tn.TelefonType.telefonType1.ToString();
                FriendPhone.Add(cvtd);
            }
            if (inMvt.TelefonNrs.Count <= 0)
            {
                FriendPhone.Add(new ClassFriendPhoneData());
            }
            FriendNewPhone = FriendPhone;
        }

        public List<ClassFriendPhoneData> FriendNewPhone { get; set; }

        public MainVenneTabel FriendData { get; set; }
    }
}
