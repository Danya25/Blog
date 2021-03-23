using AutoMapper;
using MyBlog.Models.Busines;
using MyBlog.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogDTO, BlogModel>();
            CreateMap<BlogModel, Models.Entity.Blog>();
            CreateMap<Models.Entity.Blog, BlogModel>();
            CreateMap<BlogModel, BlogDTO>();
        }
    }
}
