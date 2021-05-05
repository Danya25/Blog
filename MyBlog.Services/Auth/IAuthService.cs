using MyBlog.Domain.Business;
using System.Threading.Tasks;

namespace MyBlog.Services.Auth
{
    public interface IAuthService
    {
        public Task<UserInfoModel> Login(UserModel user);
        public Task<bool> Registration(UserModel user);
    }
}
