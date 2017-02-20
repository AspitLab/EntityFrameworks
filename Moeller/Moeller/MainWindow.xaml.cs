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

namespace Moeller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SchoolEntities1 db = new SchoolEntities1();
        public MainWindow()
        {
            InitializeComponent();
            updateListBoxPeople();
        }

        private void updateListBoxPeople()
        {
            IOrderedQueryable<Person> query = from zyx in db.People orderby zyx.FirstName select zyx;
            ListboxPeople.Items.Clear();
            foreach (Person item in query)
            {
                ListboxPeople.Items.Add($"{item.FirstName} {item.LastName}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.People.Add(new Person() { FirstName = TextBoxFirstName.Text, LastName = TextBoxLastName.Text, EnrollmentDate = new DateTime(2016, 10, 27) });
            db.SaveChanges();
            Label.Content = "New person added!";
            updateListBoxPeople();
        }
    }
}
