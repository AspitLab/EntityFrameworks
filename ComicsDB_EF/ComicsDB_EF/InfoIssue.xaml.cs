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
    /// Interaction logic for InfoIssue.xaml
    /// </summary>
    public partial class InfoIssue : Window
    {
        public InfoIssue(string strFormat, string strLanguage, DateTime? dtDate, string strComments, byte[] bytImage)
        {
            InitializeComponent();
            //Sets the content of the window
            imageImg.Source = LoadImage(bytImage);
            labelFormat.Content = "Format: " + strFormat;
            labelLanguage.Content = "Language: " + strLanguage;
            labelDate.Content = "Date of publication: " + dtDate.ToString();
            textBlockComments.Text = "Comments: " + strComments;
        }

        /// <summary>
        /// Turns a byte array into a bitmap
        /// </summary>
        /// <param name="bytImage">The image taken from the database</param>
        /// <returns>The image as a bitmap</returns>
        private static BitmapImage LoadImage(byte[] bytImage)
        {
            if (bytImage == null || bytImage.Length == 0) return null; //Returns null if the byte array is empty
            var image = new BitmapImage();
            using (var mem = new MemoryStream(bytImage))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
