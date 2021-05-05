using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class QueryPagination
    {
        [FromQuery] 
        [Required]
        [Range(0, int.MaxValue)]
        public int CurrentCount { get; set; }

        [FromQuery]
        [Range(0, 100)]
        [DefaultValue(10)]
        public int PageSize { get; set; }
    }
}
