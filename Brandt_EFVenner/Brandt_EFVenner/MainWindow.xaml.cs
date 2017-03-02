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
        private ClassVen classVen = new ClassVen();
        public MainWindow()
        {
            InitializeComponent();
            listViewVen.DataContext = cb;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource mainVenneTabelViewSource = ((CollectionViewSource)(FindResource("mainVenneTabelViewSource")));

            cb.UpdateVen();
        }

        private void listViewVen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lvi = (sender as ListView).SelectedItem;
            if (lvi != null)
            {
                ClassVen cv = lvi as ClassVen;

                MessageBox.Show(cv.venData.fornavn.ToString() + " " + cv.venData.efternavn.ToString() + "\n" +
                    cv.venData.adresse.ToString() + "\n" +
                    cv.venData.postNr.ToString() + " " + cv.venData.PostByTabel.byNavn.ToString() + "\n" +
                    cv.venNewTelefon[0].strTelefonNr.ToString() + " " + cv.venNewTelefon[0].strTelefonType.ToString());
            }
        }
    }
}
