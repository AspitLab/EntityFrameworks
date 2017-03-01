using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moeller_EFVenner
{
    public class ClassFriend : DbContext
    {
        List<ClassFriendPhoneData> venTelefon = new List<ClassFriendPhoneData>();

        public ClassFriend()
        {

        }

        public ClassFriend(MainVenneTabel inMvt)
        {
            foreach (TelefonNr tn in inMvt.TelefonNrs)
            {
                ClassFriendPhoneData cvtd = new ClassFriendPhoneData();
                cvtd.strTelefonNr = tn.telefonNr1.ToString();
                cvtd.strTelefonType = tn.TelefonType.telefonType1.ToString();
                this.venTelefon.Add(cvtd);
            }
            if (inMvt.TelefonNrs.Count <= 0)
            {
                this.venTelefon.Add(new ClassFriendPhoneData());
            }
            friendNewTelefon = venTelefon;
        }
        public List<ClassFriendPhoneData> friendNewTelefon { get; set; }

        public MainVenneTabel friendData { get; set; }

    }
}
