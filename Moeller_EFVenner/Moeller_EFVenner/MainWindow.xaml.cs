using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Moeller_EFVenner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClassBizz cb = new ClassBizz();
        private ClassFriend classFriend = new ClassFriend();
        public MainWindow()
        {
            InitializeComponent();
            listViewFriend.DataContext = cb;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource mainVenneTabelViewSource = ((CollectionViewSource)(FindResource("mainVenneTabelViewSource")));
            cb.UpdateFriend();
        }

        private void listViewFriend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lvi = (sender as ListView).SelectedItem;
            if (lvi != null)
            {
                ClassFriend cv = lvi as ClassFriend;

                MessageBox.Show(cv.FriendData.fornavn.ToString() + " " + cv.FriendData.efternavn.ToString() + "\n" +
                    cv.FriendData.adresse.ToString() + "\n" +
                    cv.FriendData.postNr.ToString() + " " + cv.FriendData.PostByTabel.byNavn.ToString() + "\n" +
                    cv.FriendNewPhone[0].strPhoneNr.ToString() + " " + cv.FriendNewPhone[0].strPhoneType.ToString());
            }
        }
    }
}
