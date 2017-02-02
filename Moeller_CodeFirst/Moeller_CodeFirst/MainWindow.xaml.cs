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

namespace Moeller_CodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BloggingContext db = new BloggingContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBoxBlogs.Items.Clear();
            Blog blog = new Blog { Name = TextBoxBlogName.Text };
            db.Blogs.Add(blog);
            db.SaveChanges();

            var query = from newBlog in db.Blogs orderby newBlog.Name select newBlog;
            foreach (var item in query)
            {
                ListBoxBlogs.Items.Add(item.Name);
            }
        }
    }
}
