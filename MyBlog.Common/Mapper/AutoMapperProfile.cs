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
            CreateMap<BlogModel, Blog>().ReverseMap();
            CreateMap<BlogModel, BlogDTO>();
            CreateMap<Blog, BlogDTO>();

            CreateMap<UserRegistrationDTO, UserModel>();
            CreateMap<UserLoginDTO, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<UserInfoDTO, UserInfoModel>().ReverseMap();

            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<RoleModel, RoleDTO>().ReverseMap();

        }
    }
}
