﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Jens_EFVenner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClassBiz cb = new ClassBiz();
        private ClassVen classVen = new ClassVen();
        public MainWindow()
        {
            InitializeComponent();
            this.listViewVen.DataContext = cb;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource mainVenneTabelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainVenneTabelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // mainVenneTabelViewSource.Source = [generic data source]

            //  var collection = new ObservableCollection<string>();
            //var collectionView = CollectionViewSource.GetDefaultView(mainVenneTabelViewSource);

            cb.UpdateVen();

            // this.listViewVen.ItemsSource = cb.Ven.SelectMany<; // mainVenneTabelViewSource as System.Collections.IEnumerable;
        }

        private void listViewVen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //System.Windows.Data.CollectionViewSource mainVenneTabelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainVenneTabelViewSource")));

            var lvi = (sender as ListView).SelectedItem;
            if (lvi != null)
            {
                
                ClassVen cv = lvi as ClassVen;
                
                

               // MainVenneTabel mvt = cv.venData as MainVenneTabel;

                MessageBox.Show(cv.venData.fornavn.ToString() + " " + cv.venData.efternavn.ToString() + "\n" + 
                    cv.venData.adresse.ToString() + "\n" + 
                    cv.venData.postNr.ToString() + " " + cv.venData.PostByTabel.byNavn.ToString() + "\n" + 
                    cv.venData.TelefonNrs[0].telefonNr1 + " " + cv.venData.TelefonNrs[0].type.ToString());
            }

        }
    }
}
