using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.Entity
{
    public class BlogLike
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
