using MyEats.Domain;
using MyEats.Business.Models;
using Microsoft.Extensions.Logging;
using MyEats.Domain.Entities;

namespace MyEats.Business.Repository
{
    public class PostcodeRepository : RepositoryBase<PostcodeEntity>, IPostcodeRepository
    {
        public PostcodeRepository(MyEatsDataContext context)
            : base(context)
        {
        }
    }
}
