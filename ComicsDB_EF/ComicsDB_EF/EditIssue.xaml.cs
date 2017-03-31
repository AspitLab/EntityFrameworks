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
    /// Interaction logic for EditIssue.xaml
    /// </summary>
    public partial class EditIssue : Window
    {
        ClassBizz CB = new ClassBizz();
        MainWindow MW;
        byte[] bytImage;
        public object LVI; //The tag of the selected issue
        public int ID; //The Idatabase key of the selected series
        public EditIssue(MainWindow MW, string Series, int Number, string Writer, string Penciller, string Format, string Language, DateTime? Date, string Comments, byte[] bytImage, object LVI, int ID)
        {
            InitializeComponent();
            this.MW = MW;
            textBoxSeries.Text = Series;
            textBoxNumber.Text = Number.ToString();
            textBoxWriter.Text = Writer;
            textBoxPenciller.Text = Penciller;
            textBoxFormat.Text = Format;
            textBoxLanguage.Text = Language;
            datePickerDate.SelectedDate = Date;
            textBoxComments.Text = Comments;
            this.bytImage = bytImage;

            this.LVI = LVI;
            this.ID = ID;
        }

        private void buttonImage_Click(object sender, RoutedEventArgs e)
        {

            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                dlg.DefaultExt = ".png";
                dlg.Filter = "JPG Files (*.jpg)|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|*.jpg|GIF Files (*.gif)|*.gif";

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    bytImage = File.ReadAllBytes(dlg.FileName);
                }
            }
        }

        /// <summary>
        /// Sets the strings and int to the edited values. Calls method to edit the database entry. Calls method to update listViewIssues in MainWindow
        /// </summary>
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            //Stores the edited data
            string strSeries = textBoxSeries.Text;
            int intNumber;
            int.TryParse(textBoxNumber.Text, out intNumber);
            string strWriter = textBoxWriter.Text;
            string strPenciller = textBoxPenciller.Text;
            string strFormat = textBoxFormat.Text;
            string strLanguage = textBoxLanguage.Text;
            DateTime? dtDate = datePickerDate.SelectedDate;
            string strComments = textBoxComments.Text;

            //Calls method to edit the database entry
            CB.EditIssue(strSeries, intNumber, strWriter, strPenciller, strFormat, strLanguage, dtDate, strComments, bytImage, LVI);

            //Calls method to update listViewIssues in MainWindow and confirms action
            CB.UpdateListviewIssues(ID);
            MW.listViewIssues.ItemsSource = CB._listViewIssues;
            MessageBox.Show(Title="Issue Updated", "Issue updated");
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
