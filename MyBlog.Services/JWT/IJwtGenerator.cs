using MyBlog.DAL.Entity;

namespace MyBlog.Services.JWT
{
    public interface IJwtGenerator
    {
        string CreateToken(DAL.Entity.User user);
    }
}
