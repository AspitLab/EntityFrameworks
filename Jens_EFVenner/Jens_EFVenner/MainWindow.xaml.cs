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

namespace Jens_EFVenner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClassVen classVen = new ClassVen();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource mainVenneTabelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainVenneTabelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // mainVenneTabelViewSource.Source = [generic data source]
            classVen.c
           

            this.listViewVen.ItemsSource = mainVenneTabelViewSource as System.Collections.IEnumerable;
        }
    }
}
