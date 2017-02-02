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
            UpdateBlogs();
        }

        public void UpdateBlogs()
        {
            ListBoxBlogs.Items.Clear();
            var query = from newBlog in db.Blogs orderby newBlog.Name select newBlog;
            foreach (var item in query)
            {
                ListBoxBlogs.Items.Add(item.Name);
            }
        }

        private void ButtonAddBlog_Click(object sender, RoutedEventArgs e)
        {
            Blog blog = new Blog { Name = TextBoxBlogName.Text };
            db.Blogs.Add(blog);
            db.SaveChanges();
            UpdateBlogs();
        }
        private void ButtonRemoveBlog_Click(object sender, RoutedEventArgs e)
        {
            Blog blog = new Blog { Name = TextBoxBlogName.Text };
            db.Blogs.Remove(blog);
            db.SaveChanges();
            UpdateBlogs();
        }
    }
}
