using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsDB_EF
{
    class ClassComics
    {
        ComicsContext CTX = new ComicsContext();
        public ClassComics()
        {
        }

        public ClassComics(Series s)
        {
        }

        public ClassComics(Issues I)
        {
        }

        public Series SeriesData { get; set; }
        public Issues IssuesData { get; set; }

        /// <summary>
        /// Types used to store data from the selected series
        /// </summary>
        #region Series Names
        public int ID;
        public string Publisher;
        public string Universe;
        public string Series;
        public int CollIss;
        public int Year;
        public string Comments;
        public byte[] bytImage;
        #endregion

        /// <summary>
        /// Sets the types used to store data from the selected series
        /// </summary>
        public void GetSeriessData()
        {
            ID = SeriesData.ID;
            Publisher = SeriesData.strPublisher;
            Universe = SeriesData.strUniverse;
            Series = SeriesData.strSeries;
            CollIss = SeriesData.intCollIss;
            Year = SeriesData.intYear;
            Comments = SeriesData.strComments;
            bytImage = SeriesData.bytImage;
        }

        /// <summary>
        /// Types used to store data from the selected issue
        /// </summary>
        #region Issues Names
        public string SeriesIss;
        public int Number;
        public string Writer;
        public string Penciller;
        public string Format;
        public string Language;
        public DateTime? Date;
        public string CommentsIss;
        public byte[] bytImageIss;
        #endregion

        public void GetIssuesData()
        {
            SeriesIss = IssuesData.strSeries;
            Number = IssuesData.intNumber;
            Writer = IssuesData.strWriter;
            Penciller = IssuesData.strPenciller;
            Format = IssuesData.strFormat;
            Language = IssuesData.strLanguage;
            Date = IssuesData.dtDate;
            CommentsIss = IssuesData.strComments;
            bytImageIss = IssuesData.bytImage;
        }

        /// <summary>
        /// Deletes the selected series
        /// </summary>
        public void DeleteSeries()
        {
            CTX.Series.Attach(SeriesData);
            CTX.Series.Remove(SeriesData);
            CTX.SaveChanges();
        }

        /// <summary>
        /// Deletes the selected issue
        /// </summary>
        public void DeleteIssue()
        {
            CTX.Issues.Attach(IssuesData);
            CTX.Issues.Remove(IssuesData);
            CTX.SaveChanges();
        }
    }
}