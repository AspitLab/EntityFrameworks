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
    /// Interaction logic for AddIssue.xaml
    /// </summary>
    public partial class AddIssue : Window
    {
        ClassBizz CB = new ClassBizz();
        MainWindow MW;
        string strSeries; //strSeries is used to store the name of the selected series
        int ID; //ID is the database key for the selected series
        public byte[] bytImage;
        public AddIssue(MainWindow MW, string strSeries, int ID)
        {
            InitializeComponent();
            this.MW = MW;
            this.strSeries = strSeries;
            this.ID = ID;

            textBoxSeries.Text = strSeries;
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

        /// <summary>
        /// Sets the strings and int to the values in the textboxes. Calls method to add the values to the database. Updates listViewIssues in MainWindow with the new entry
        /// </summary>
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            //Sets the new values
            string strSeries = textBoxSeries.Text;
            int intNumber;
            int.TryParse(textBoxNumber.Text, out intNumber);
            string strWriter = textBoxWriter.Text;
            string strPenciller = textBoxPenciller.Text;
            string strFormat = textBoxFormat.Text;
            string strLanguage = textBoxLanguage.Text;
            DateTime? dtDate = datePickerDate.SelectedDate;
            string strComments = textBoxComments.Text;

            //Calls method to add the issue
            CB.AddIssue(strSeries, intNumber, strWriter, strPenciller, strFormat, strLanguage, dtDate, strComments, bytImage, ID);

            //Resets and updates listViewIssues in MainWindow. Message box confirms the action
            CB.UpdateListviewIssues(ID);
            MW.listViewIssues.ItemsSource = CB._listViewIssues;
            MessageBox.Show(Title="Issue Added", "Issue added");
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
