using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace ComicsDB_EF
{
    /// <summary>
    /// Interaction logic for AddSeries.xaml
    /// </summary>
    public partial class AddSeries : Window
    {
        ClassBizz CB = new ClassBizz();
        MainWindow MW;
        public byte[] bytImage;
        public AddSeries(MainWindow MW)
        {
            InitializeComponent();
            this.MW = MW;
            FillComboBox();
        }

        private void FillComboBox()
        {
            int i = 1900;
            int y = DateTime.Now.Year;
            while (y >= i)
            {
                comboBoxYear.Items.Add(y);
                y--;
            }
        }

        /// <summary>
        /// Opens file explorer to choose an image
        /// </summary>
        private void buttonImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();

            if ( result == true)
            {
                bytImage = File.ReadAllBytes(dlg.FileName);
            }
        }

        /// <summary>
        /// Adds a new series to the database
        /// </summary>
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string strPublisher = textBoxPublisher.Text;
            string strUniverse = textBoxUniverse.Text;
            string strSeries = textBoxSeries.Text;
            int intCollIss = 1;
            int.TryParse(textBoxCollIssues.Text, out intCollIss);
            int intYear = 1900;
            try { int.TryParse(comboBoxYear.SelectedItem.ToString(), out intYear); } catch { }
            string strComments = textBoxComments.Text;

            //Calls method to add new series to the database. The strings and ints store the added data
            CB.AddSeries(strPublisher, strUniverse, strSeries, intCollIss, intYear, strComments, bytImage);

            //Updates the listview
            CB.UpdateListviewSeries();
            MW.listViewSeries.ItemsSource = CB._listViewSeries;
            MessageBox.Show(Title="Series added", "Series added");
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
