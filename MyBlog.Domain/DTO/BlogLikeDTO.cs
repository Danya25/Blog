using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.DTO
{
    public class BlogLikeDTO
    {
        public int BlogId { get; set; }
        public bool LikeStatus { get; set; }
    }
}
