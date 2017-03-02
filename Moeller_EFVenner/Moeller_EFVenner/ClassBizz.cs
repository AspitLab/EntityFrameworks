using System.Collections.ObjectModel;

namespace Moeller_EFVenner
{
    class ClassBizz
    {

        public ClassBizz()
        {

        }

        public void UpdateFriend()
        {

            string strSql = "Select * from MainVenneTabel";

            using (var ctx = new FriendsEntities())
            {
                var myVen = ctx.MainVenneTabels.SqlQuery(strSql);
                foreach (MainVenneTabel i in myVen)
                {
                    ClassFriend cf = new ClassFriend(i);
                    cf.FriendData = i;
                    friend.Add(cf);
                }
            }
        }

        ObservableCollection<ClassFriend> friend = new ObservableCollection<ClassFriend>();
        public ObservableCollection<ClassFriend> Friend
        {
            get
            {
                return friend;
            }
        }

    }
}
