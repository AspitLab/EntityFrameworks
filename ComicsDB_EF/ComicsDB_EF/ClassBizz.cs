using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsDB_EF
{
    class ClassBizz
    {
        ClassAdd CA = new ClassAdd();
        ClassEdit CE = new ClassEdit();
        object LVI;
        public ClassBizz()
        {
        }

        /// <summary>
        /// Adds series to an observable collection for each entry in the database
        /// </summary>
        #region Update Listview Series
        public void UpdateListviewSeries()
        {
            //Clears listViewSeries if entries already exist
            if (listViewSeries.Count > 0)
            {
                listViewSeries.Clear();
            }

            //Uses strSQL to select all entries and adds them to listViewSeries
            string strSQL = "SELECT * FROM Series";

            using (var ctx = new ComicsContext())
            {
                var Series = ctx.Series.SqlQuery(strSQL);
                foreach (Series s in Series)
                {
                    ClassComics CC = new ClassComics(s);
                    CC.SeriesData = s;
                    listViewSeries.Add(CC);
                }
            }
        }

        ObservableCollection<ClassComics> listViewSeries = new ObservableCollection<ClassComics>();
        public ObservableCollection<ClassComics> _listViewSeries
        {
            get
            {
                return listViewSeries;
            }
        }
        #endregion

        /// <summary>
        /// Adds issues to an observable collection for each entry int the database
        /// </summary>
        /// <param name="ID">The ID of the selected series. Acts as a foreign key</param>
        #region Update Listview Issues
        public void UpdateListviewIssues(int ID)
        {
            //Clears listViewIssues if entries already exist
            if (listViewIssues.Count > 0)
            {
                listViewIssues.Clear();
            }

            //Uses strSQL to select all entries and adds them to listViewIssues
            string strSQL = $"SELECT * FROM Issues WHERE SeriesID = '{ID}'";

            using (var ctx = new ComicsContext())
            {
                var Issues = ctx.Issues.SqlQuery(strSQL);
                foreach (Issues i in Issues)
                {
                    ClassComics CC = new ClassComics(i);
                    CC.IssuesData = i;
                    listViewIssues.Add(CC);
                }
            }
        }

        ObservableCollection<ClassComics> listViewIssues = new ObservableCollection<ClassComics>();
        public ObservableCollection<ClassComics> _listViewIssues
        {
            get
            {
                return listViewIssues;
            }
        }
        #endregion

        /// <summary>
        /// Calls a method to add new series to the database. The strings and ints store the added data
        /// </summary>
        public void AddSeries(string strPublisher, string strUniverse, string strSeries, int intCollIss, int intYear, string strComments, byte[] bytImage)
        {
            CA.AddSeries(strPublisher, strUniverse, strSeries, intCollIss, intYear, strComments, bytImage);
        }

        /// <summary>
        /// Calls a method to add new issues to the database. The strings and int store the added data. ID is the ID of the selected series and acts as a foreign key
        /// </summary>
        public void AddIssue(string strSeries, int intNumber, string strWriter, string strPenciller, string strFormat, string strLanguage, DateTime? dtDate, string strComments, byte[] bytImage, int ID)
        {
            CA.AddIssue(strSeries, intNumber, strWriter, strPenciller, strFormat, strLanguage, dtDate, strComments, bytImage, ID);
        }

        /// <summary>
        /// Calls a method to edit a series in the database. The strings and ints store the edited data. LVI stores the tag of the edited series
        /// </summary>
        public void EditSeries(string strPublisher, string strUniverse, string strSeries, int intCollIss, int intYear, string strComments, byte[] bytImage, object LVI)
        {
            this.LVI = LVI;
            CE.EditSeries(strPublisher, strUniverse, strSeries, intCollIss, intYear, strComments, bytImage, LVI);
        }

        /// <summary>
        /// Calls a method to edit an issue in the database. The strings and int store the edited data. LVI stores the tag of the edited issue
        /// </summary>
        public void EditIssue(string strSeries, int intNumber, string strWriter, string strPenciller, string strFormat, string strLanguage, DateTime? dtDate, string strComments, byte[] bytImage, object LVI)
        {
            this.LVI = LVI;
            CE.EditIssue(strSeries, intNumber, strWriter, strPenciller, strFormat, strLanguage, dtDate, strComments, bytImage, LVI);
        }

        /// <summary>
        /// Finds entries in the table series matching the search query. String version
        /// </summary>
        /// <param name="strSearch">The search query used</param>
        public void SearchSeries(string strSearch)
        {
            //Checks if items are already present in listViewSeries and clears if true
            if (listViewSeries.Count > 0)
            {
                listViewSeries.Clear();
            }

            //Uses strSQL to find all entries related to the search query and adds them to listViewSeries
            string strSQL = $"SELECT * FROM Series WHERE ((strPublisher LIKE '%{strSearch}%') OR (strUniverse LIKE '%{strSearch}%') OR ( strSeries LIKE '%{strSearch}%') OR (strComments LIKE '%{strSearch}%'))";
            using (var ctx = new ComicsContext())
            {
                var series = ctx.Series.SqlQuery(strSQL);
                foreach (Series s in series)
                {
                    ClassComics CC = new ClassComics(s);
                    CC.SeriesData = s;
                    listViewSeries.Add(CC);
                }
            }
        }

        /// <summary>
        /// Finds entries in the table series matching the search query. Int version
        /// </summary>
        /// <param name="strSearch">The search query used</param>
        public void SearchSeries(int intSearch)
        {
            //Checks if items are already present in listViewSeries and clears if true
            if (listViewSeries.Count > 0)
            {
                listViewSeries.Clear();
            }

            //Uses strSQL to find all entries related to the search query and adds them to listViewSeries
            string strSQL = $"SELECT * FROM Series WHERE ((intCollIss LIKE '%{intSearch}%') OR (intYear LIKE '%{intSearch}%'))";
            using (var ctx = new ComicsContext())
            {
                var series = ctx.Series.SqlQuery(strSQL);
                foreach (Series s in series)
                {
                    ClassComics CC = new ClassComics(s);
                    CC.SeriesData = s;
                    listViewSeries.Add(CC);
                }
            }
        }

        /// <summary>
        /// Finds entries in the table issues matching the search query. String version
        /// </summary>
        /// <param name="strSearch">The search query used</param>
        public void SearchIssues(string strSearch)
        {
            //Checks if items are already present in listViewIssues and clears if true
            if (listViewIssues.Count > 0)
            {
                listViewIssues.Clear();
            }

            //Uses strSQL to find all entries related to the search query and adds them to listViewIssues
            string strSQL = $"SELECT * FROM Issues WHERE ((strSeries LIKE '%{strSearch}%') OR (strWriter LIKE '%{strSearch}%') OR ( strPenciller LIKE '%{strSearch}%') OR ( strFormat LIKE '%{strSearch}%') OR ( strLanguage LIKE '%{strSearch}%') OR (strComments LIKE '%{strSearch}%'))";
            using (var ctx = new ComicsContext())
            {
                var issue = ctx.Issues.SqlQuery(strSQL);
                foreach (Issues i in issue)
                {
                    ClassComics CC = new ClassComics(i);
                    CC.IssuesData = i;
                    listViewIssues.Add(CC);
                }
            }
        }

        /// <summary>
        /// Finds entries in the table issues matching the search query. Int version
        /// </summary>
        /// <param name="strSearch">The search query used</param>
        public void SearchIssues(int intSearch)
        {
            //Checks if items are already present in listViewIssues and clears if true
            if (listViewIssues.Count > 0)
            {
                listViewIssues.Clear();
            }

            //Uses strSQL to find all entries related to the search query and adds them to listViewIssues
            string strSQL = $"SELECT * FROM Issues WHERE ((intNumber LIKE '%{intSearch}%') OR (dtDate LIKE '%{intSearch}%'))";
            using (var ctx = new ComicsContext())
            {
                var issue = ctx.Issues.SqlQuery(strSQL);
                foreach (Issues i in issue)
                {
                    ClassComics CC = new ClassComics(i);
                    CC.IssuesData = i;
                    listViewIssues.Add(CC);
                }
            }
        }
    }
}
