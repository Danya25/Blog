﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Domain.Business
{
    public class UserModel
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}
