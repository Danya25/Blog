using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Domain.Business
{
    public sealed class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Username { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool IsLike { get; set; }
        public int CountLikes { get; set; }
    }
}
