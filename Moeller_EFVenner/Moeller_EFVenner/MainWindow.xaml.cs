using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            System.Windows.Data.CollectionViewSource mainVenneTabelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainVenneTabelViewSource")));
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
