using System;
using System.Collections.Generic;
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
            this.listViewVen.DataContext = cb;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource mainVenneTabelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainVenneTabelViewSource")));

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
