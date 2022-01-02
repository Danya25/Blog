using System.Threading;
using System.Threading.Tasks;
using MyBlog.Domain.Business;
using MyBlog.Domain.Queries;

namespace MyBlog.Services.Photo
{
    public class PhotoHandler : IQueryHandler<PhotoQuery, PhotoInfoModel>
    {
        public Task<PhotoInfoModel> Handle(PhotoQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}