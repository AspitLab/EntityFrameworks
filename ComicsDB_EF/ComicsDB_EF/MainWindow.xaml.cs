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

namespace ComicsDB_EF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBizz CB = new ClassBizz();
        int ID;
        public MainWindow()
        {
            InitializeComponent();
            listViewSeries.DataContext = CB;
        }

        /// <summary>
        /// Loads the series listview with series from the database
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listViewSeries.ItemsSource = CB._listViewSeries;
            CB.UpdateListviewSeries();
        }

        /// <summary>
        /// Opens a new window used to add series to the database
        /// </summary>
        private void buttonAddSeries_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = this;
            AddSeries AS = new AddSeries(MW);
            AS.ShowDialog();
        }

        /// Opens a new window used to edit series in the database
        /// </summary>
        private void buttonEditSeries_Click(object sender, RoutedEventArgs e)
        {
            var LVI = listViewSeries.SelectedItem;
            if (LVI != null) //Checks if a series is selected
            {
                //Types used to store data of the selected series
                ClassComics CCLVI = LVI as ClassComics;
                CCLVI.GetSeriessData();
                string Publisher = CCLVI.Publisher;
                string Universe = CCLVI.Universe;
                string Series = CCLVI.Series;
                int CollIss = CCLVI.CollIss;
                int Year = CCLVI.Year;
                string Comments = CCLVI.Comments;
                byte[] Image = CCLVI.bytImage;

                MainWindow MW = this;

                EditSeries ES = new EditSeries(MW, Publisher, Universe, Series, CollIss, Year, Comments, Image, LVI);
                ES.ShowDialog();
            }
            //Messagebox if a series is not selected
            else
            {
                MessageBox.Show("The Duck Council is dissapointed \n Choose a series to update");
            }
        }

        /// Deletes the selected series
        /// </summary>
        private void buttonDelSeries_Click(object sender, RoutedEventArgs e)
        {
            var LVI = listViewSeries.SelectedItem;
            if (LVI != null) //Checks if a series is selected
            {
                ClassComics CCLVI = LVI as ClassComics;
                CCLVI.DeleteSeries();

                //Updates the series listview
                CB.UpdateListviewSeries();
            }
            //Messagebox if a series is not selected
            else
            {
                MessageBox.Show("The duck council is dissapointed \n Choose a series to delete");
            }
        }

        /// Opens a new window used to add issues to the database
        /// </summary>
        private void buttonAddIssues_Click(object sender, RoutedEventArgs e)
        {
            var LVI = listViewSeries.SelectedItem;
            if (LVI != null)
            {
                ClassComics CCLVI = LVI as ClassComics;
                CCLVI.GetSeriessData();
                string strSeries = CCLVI.Series;
                int ID = CCLVI.ID;

                MainWindow MW = this;

                AddIssue AI = new AddIssue(MW, strSeries, ID);
                AI.ShowDialog();
            }
            else
            {
                MessageBox.Show("The Duck Council is dissapointed \n Choose a series to add issues");
            }
        }

        /// Opens a new window used to edit issues in the database
        /// </summary>
        private void buttonEditIssues_Click(object sender, RoutedEventArgs e)
        {
            var LVI = listViewIssues.SelectedItem;
            if (LVI != null) //Checks if an issue is selected
            {
                //Types used to store data from the selected issue
                ClassComics CCLVI = LVI as ClassComics;
                CCLVI.GetIssuesData();
                string Series = CCLVI.SeriesIss;
                int Number = CCLVI.Number;
                string Writer = CCLVI.Writer;
                string Penciller = CCLVI.Penciller;
                string Format = CCLVI.Format;
                string Language = CCLVI.Language;
                DateTime? Date = CCLVI.Date;
                string Comments = CCLVI.Comments;
                byte[] bytImage = CCLVI.bytImageIss;

                MainWindow MW = this;

                EditIssue EI = new EditIssue(MW, Series, Number, Writer, Penciller, Format, Language, Date, Comments, bytImage, LVI, ID);
                EI.ShowDialog();
            }
            //Messagebox if a series is not selected
            else
            {
                MessageBox.Show("The Duck Council is dissapointed \n Choose an issue to update");
            }
        }

        /// <summary>
        /// Deletes the selected issue
        /// </summary>
        private void buttonDelIssues_Click(object sender, RoutedEventArgs e)
        {
            var LVI = listViewIssues.SelectedItem;
            if (LVI != null) //Checks if an issue is selected
            {
                ClassComics CCLVI = LVI as ClassComics;
                CCLVI.DeleteIssue();

                CB.UpdateListviewIssues(ID);
            }
            //Messagebox if an issue is not selected
            else
            {
                MessageBox.Show("The duck council is dissapointed \n Choose an issue to delete");
            }
        }

        /// <summary>
        /// Updates listViewIssues with issues from the selected series
        /// </summary>
        private void listViewSeries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var LVI = listViewSeries.SelectedItem;
            if (LVI != null) //Checks if a series is selected
            {
                ClassComics CCLVI = LVI as ClassComics;
                CCLVI.GetSeriessData();
                ID = CCLVI.ID;

                listViewIssues.ItemsSource = CB._listViewIssues;
                CB.UpdateListviewIssues(ID);
            }
        }

        /// <summary>
        /// Opens an info window when double clicking on a series
        /// </summary>
        private void listViewSeries_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var LVI = listViewSeries.SelectedItem;
            if (LVI != null) //Checks if a series is selected
            {
                //Types used to store the data for the info window
                ClassComics CCLVI = LVI as ClassComics;
                CCLVI.GetSeriessData();
                int Year = CCLVI.Year;
                string Comments = CCLVI.Comments;
                byte[] bytImage = CCLVI.bytImage;

                InfoSeries IS = new InfoSeries(Year, Comments, bytImage);
                IS.ShowDialog();
            }
        }

        /// <summary>
        /// Opens an info window when double clicking on an issue
        /// </summary>
        private void listViewIssues_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var LVI = listViewIssues.SelectedItem;
            if (LVI != null) //Checks if an issue is selected
            {
                //Types used to store data for the info window
                ClassComics CCLVI = LVI as ClassComics;
                CCLVI.GetIssuesData();
                string strFormat = CCLVI.Format;
                string strLanguage = CCLVI.Language;
                DateTime? dtDate = CCLVI.Date;
                string strComments = CCLVI.Comments;
                byte[] bytImage = CCLVI.bytImageIss;

                InfoIssue IF = new InfoIssue(strFormat, strLanguage, dtDate, strComments, bytImage);
                IF.ShowDialog();
            }
        }

        /// <summary>
        /// Search function for series
        /// </summary>
        private void buttonSearchSeries_Click(object sender, RoutedEventArgs e)
        {
            //Tryparse the search query. If the result is positive, it runs SearchSeries int version, else string version
            int intSearch;
            bool booIntSearch = int.TryParse(textBoxSearchSeries.Text, out intSearch);
            if (booIntSearch)
            {
                CB.SearchSeries(intSearch);
            }
            else
            {
                string strSearch = textBoxSearchSeries.Text;
                CB.SearchSeries(strSearch);
            }
        }

        /// <summary>
        /// Search function for issues
        /// </summary>
        private void buttonSearchIssues_Click(object sender, RoutedEventArgs e)
        {
            //Tryparse the search query. If the result is positive, it runs SearchSeries int version, else string version
            int intSearch;
            bool booIntSearch = int.TryParse(textBoxSearchIssues.Text, out intSearch);
            if (booIntSearch)
            {
                CB.SearchIssues(intSearch);
            }
            else
            {
                string strSearch = textBoxSearchIssues.Text;
                CB.SearchIssues(strSearch);
            }
            listViewIssues.ItemsSource = CB._listViewIssues;
        }
    }
}
