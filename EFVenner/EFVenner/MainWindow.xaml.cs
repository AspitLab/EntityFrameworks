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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.EntityClient;
using System.Data;

namespace EFVenner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ClassBizz cb = new ClassBizz();
        MainVenneTabel MVT = new MainVenneTabel();

        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = cb;
        }

        private void listViewVen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var lvi = (sender as ListView).SelectedItem;
                if (lvi != null)
                {
                    ClassVen cv = lvi as ClassVen;
                    MainVenneTabel mvi = cv.venData as MainVenneTabel;
                    MessageBox.Show(mvi.fornavn.ToString() + " " + mvi.efternavn.ToString() + "\n" + mvi.adresse.ToString() + "\n" + mvi.postNr.ToString() + " " + mvi.PostByTabel.byNavn.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var ctx = new VennerEntities())
            {
                var minVen = ctx.MainVenneTabels.SqlQuery("Select * from MainVenneTabel");
                foreach (MainVenneTabel i in minVen)
                {

                    this.listViewVen.Items.Add(new ClassVen { FNavn = i.fornavn.ToString(), ENavn = i.efternavn.ToString(), venData = i , postData = i.PostByTabel.byNavn.ToString()});
                }
            }
        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var ctx = new VennerEntities())
            {

                List<MainVenneTabel> studentName = ctx.MainVenneTabels.SqlQuery("Select id, fornavn, efternavn, adresse, postNr from MainVenneTabel").ToList<MainVenneTabel>();
                foreach (MainVenneTabel i in studentName)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Content = i.fornavn + " " + i.efternavn;
                    lvi.Tag = i.id;
                    this.listBoxMainVen.Items.Add(lvi);
                }
            }
        }


    }
}
