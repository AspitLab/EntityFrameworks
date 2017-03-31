using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsDB_EF
{
    class ClassAdd
    {
        ClassComics CC = new ClassComics();
        ComicsContext CTX = new ComicsContext();
        public ClassAdd()
        {

        }

        /// <summary>
        /// Adds a new series to the database. The strings and ints store the added data
        /// </summary>
        public void AddSeries(string strPublisher, string strUniverse, string strSeries, int intCollIss, int intYear, string strComments, byte[] bytImage)
        {
            var newSeries = new Series();

            //Sets the added values
            newSeries.strPublisher = strPublisher;
            newSeries.strUniverse = strUniverse;
            newSeries.strSeries = strSeries;
            newSeries.intCollIss = intCollIss;
            newSeries.intYear = intYear;
            newSeries.strComments = strComments;
            newSeries.bytImage = bytImage;

            //Adds the entry and saves
            CTX.Entry(newSeries).State = EntityState.Added;
            CTX.SaveChanges();
        }

        /// <summary>
        /// Adds a new issue to the database. The strings and ints store the added data
        /// </summary>
        public void AddIssue(string strSeries, int intNumber, string strWriter, string strPenciller, string strFormat, string strLanguage, DateTime? dtDate, string strComments, byte[] bytImage, int ID)
        {
            var newIssue = new Issues();

            //Sets the added values
            newIssue.SeriesID = ID;
            newIssue.strSeries = strSeries;
            newIssue.intNumber = intNumber;
            newIssue.strWriter = strWriter;
            newIssue.strPenciller = strPenciller;
            newIssue.strFormat = strFormat;
            newIssue.strLanguage = strLanguage;
            newIssue.dtDate = dtDate;
            newIssue.strComments = strComments;
            newIssue.bytImage = bytImage;

            //Adds the entry and saves
            CTX.Entry(newIssue).State = EntityState.Added;
            CTX.SaveChanges();
        }
    }
}
