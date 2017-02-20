using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moeller_CodeFirst_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BlogContext db = new BlogContext())
            {
                string myString = "1lasdf";
                Console.WriteLine(myString.GetType().ToString());
                IOrderedQueryable<Blog> query = from b in db.Blogs orderby b.Name select b;
                Console.WriteLine(query.GetType().ToString());
                foreach (Blog item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.Write("Enter blog name: ");
                string name = Console.ReadLine();

                Blog blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Name{ get; set; }

            public virtual List<Post> Posts { get; set; }
        }

        public class Post
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public int BlogId { get; set; }
            public virtual Blog Blog { get; set; }
        }

        public class BlogContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
    }
}
