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
using System.Windows.Shapes;

namespace Brandt_EFVenner
{
    /// <summary>
    /// Interaction logic for AddFriend.xaml
    /// </summary>
    public partial class AddFriend : Window
    {
        ClassBizz cb;
        MainWindow mw;
        ClassVen cv = new ClassVen();
        public AddFriend(ClassBizz cb, MainWindow mw)
        {
            InitializeComponent();
            this.cb = cb;
            this.mw = mw;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string strAddFornavn = textBoxFornavn.Text;
            string strAddEfternavn = textBoxEfternavn.Text;
            string strAddAdresse = textBoxAdresse.Text;
            int intAddPostNr;
            int.TryParse(textBoxPostNr.Text, out intAddPostNr);

            cv.AddFriend(strAddFornavn, strAddEfternavn, strAddAdresse, intAddPostNr);

            cb.UpdateListview();
            MessageBox.Show("Ven tilføjet");
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
