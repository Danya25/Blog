using AutoMapper;
using MyBlog.DAL.Entity;
using MyBlog.Domain.Business;
using MyBlog.Domain.DTO;

namespace MyBlog.Common.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogDTO, BlogModel>();
            CreateMap<BlogModel, Blog>();
            CreateMap<Blog, BlogModel>();
            CreateMap<BlogModel, BlogDTO>();
            CreateMap<Blog, BlogDTO>();

            CreateMap<UserDTO, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<UserInfoDTO, UserInfoModel>();
            CreateMap<UserInfoModel, UserInfoDTO>();

        }
    }
}
