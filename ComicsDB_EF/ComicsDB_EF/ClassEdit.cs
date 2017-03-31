using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsDB_EF
{
    class ClassEdit
    {
        ComicsContext CTX = new ComicsContext();
        object LVI;
        public ClassEdit()
        {
        }
        /// <summary>
        /// Edits a series in the database. The strings and ints store the edited data. LVIin stores the tag of the edited series
        /// </summary>
        public void EditSeries(string strPublisher, string strUniverse, string strSeries, int intCollIss, int intYear, string strComments, byte[] bytImage, object LVI)
        {
            this.LVI = LVI;

            ClassComics CC = LVI as ClassComics;

            //Sets the new values
            CC.SeriesData.strPublisher = strPublisher;
            CC.SeriesData.strUniverse = strUniverse;
            CC.SeriesData.strSeries = strSeries;
            CC.SeriesData.intCollIss = intCollIss;
            CC.SeriesData.intYear = intYear;
            CC.SeriesData.strComments = strComments;
            CC.SeriesData.bytImage = bytImage;

            //Sets the state of the entry to modified and saves changes
            CTX.Entry(CC.SeriesData).State = EntityState.Modified;
            CTX.SaveChanges();
        }

        /// <summary>
        /// Edits an issue in the database. The strings and int store the edited data. LVI stores the tag of the edited issue
        /// </summary>
        public void EditIssue(string strSeries, int intNumber, string strWriter, string strPenciller, string strFormat, string strLanguage, DateTime? dtDate, string strComments, byte[] bytImage, object LVI)
        {
            this.LVI = LVI;

            ClassComics CC = LVI as ClassComics;

            //Sets the new values
            CC.IssuesData.strSeries = strSeries;
            CC.IssuesData.intNumber = intNumber;
            CC.IssuesData.strWriter = strWriter;
            CC.IssuesData.strPenciller = strPenciller;
            CC.IssuesData.strFormat = strFormat;
            CC.IssuesData.strLanguage = strLanguage;
            CC.IssuesData.dtDate = dtDate;
            CC.IssuesData.strComments = strComments;
            CC.IssuesData.bytImage = bytImage;

            //Sets the state of the entry to modified and saves changes
            CTX.Entry(CC.IssuesData).State = EntityState.Modified;
            CTX.SaveChanges();
        }
    }
}
