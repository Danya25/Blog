using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.DAL.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Username { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool IsLike { get; set; }
    }
}
