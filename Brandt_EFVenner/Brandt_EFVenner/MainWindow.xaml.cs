using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Brandt_EFVenner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClassBizz cb = new ClassBizz();
        public MainWindow()
        {
            InitializeComponent();
            listViewVen.DataContext = cb;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource mainVenneTabelViewSource = ((CollectionViewSource)(FindResource("mainVenneTabelViewSource")));

            cb.UpdateListview();
        }

        private void listViewVen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lvi = (sender as ListView).SelectedItem;
            if (lvi != null)
            {
                ClassVen cvLvi = lvi as ClassVen;

                cvLvi.GetVenData();
                fornavnTextBox.DataContext = cvLvi;
                efternavnTextBox.DataContext = cvLvi;
                adresseTextBox.DataContext = cvLvi;
                postNrTextBox.DataContext = cvLvi;
                bynavnTextBox.DataContext = cvLvi;

                //MessageBox.Show(cv.venData.fornavn.ToString() + " " + cv.venData.efternavn.ToString() + "\n" +
                //    cv.venData.adresse.ToString() + "\n" +
                //    cv.venData.postNr.ToString() + " " + cv.venData.PostByTabel.byNavn.ToString() + "\n" +
                //    cv.venNewTelefon[0].strTelefonNr.ToString() + " " + cv.venNewTelefon[0].strTelefonType.ToString());
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            string strFornavn = fornavnTextBox.Text;
            string strEfternavn = efternavnTextBox.Text;
            string strAdresse = adresseTextBox.Text;
            int intPostNr;
            int.TryParse(postNrTextBox.Text, out intPostNr);
            string strByNavn = bynavnTextBox.Text;

            var lvi = listViewVen.SelectedItem;
            if (lvi != null)
            {
                ClassVen cvLvi = lvi as ClassVen;
                cvLvi.UpdateVen(strFornavn, strEfternavn, strAdresse, intPostNr, strByNavn);
            }

            cb.UpdateListview();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = this;
            AddFriend af = new AddFriend(cb, mw);
            af.Show();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            var lvi = listViewVen.SelectedItem;
            if (lvi != null)
            {
                ClassVen cvLvi = lvi as ClassVen;
                cvLvi.DeleteFriend();
            }
            cb.UpdateListview();
        }
    }
}
