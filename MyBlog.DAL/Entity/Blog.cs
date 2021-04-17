﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.DAL.Entity
{
    public sealed class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string ShortDescription { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
