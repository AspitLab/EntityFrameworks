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
    /// Interaction logic for EditSeries.xaml
    /// </summary>
    public partial class EditSeries : Window
    {
        ClassBizz CB = new ClassBizz();
        MainWindow MW;
        public string Publisher;
        public string Universe;
        public string Series;
        public int CollIss;
        public int Year;
        public string Comments;
        public byte[] bytImage;
        public object LVI;

        public EditSeries(MainWindow MW, string Publisher, string Universe, string Series, int CollIss, int Year, string Comments, byte[] bytImage, object LVI)
        {
            InitializeComponent();
            this.MW = MW;
            this.Publisher = Publisher;
            this.Universe = Universe;
            this.Series = Series;
            this.CollIss = CollIss;
            this.Year = Year;
            this.Comments = Comments;
            this.bytImage = bytImage;
            this.LVI = LVI;
            FillComboBox();
            FillTextBox();
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
        /// Fills the textbox with the data from the selected series
        /// </summary>
        private void FillTextBox()
        {
            textBoxPublisher.Text = Publisher;
            textBoxUniverse.Text = Universe;
            textBoxSeries.Text = Series;
            textBoxCollIssues.Text = CollIss.ToString();
            comboBoxYear.SelectedItem = Year;
            textBoxComments.Text = Comments;
        }

        /// <summary>
        /// Edits the selected series
        /// </summary>
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            string strPublisher = textBoxPublisher.Text;
            string strUniverse = textBoxUniverse.Text;
            string strSeries = textBoxSeries.Text;
            int intCollIss;
            int.TryParse(textBoxCollIssues.Text, out intCollIss);
            int intYear;
            int.TryParse(comboBoxYear.SelectedItem.ToString(), out intYear);
            string strComments = textBoxComments.Text;

            //Calls method to edit the series. The strings and ints store the edited information. LVI stores the tag of the edited series
            CB.EditSeries(strPublisher, strUniverse, strSeries, intCollIss, intYear, strComments, bytImage, LVI);

            //Updates the series listview
            CB.UpdateListviewSeries();
            MW.listViewSeries.ItemsSource = CB._listViewSeries;
            MessageBox.Show(Title="Series Updated", "Series updated");
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

            if (result == true)
            {
                bytImage = File.ReadAllBytes(dlg.FileName);
            }
        }
    }
}
