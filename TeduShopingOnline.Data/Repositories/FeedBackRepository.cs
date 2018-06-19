using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories
{
    public class FeedBackRepository : RepositoryBase<FeedBack>, IFeedBackRepository
    {
        public FeedBackRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
