using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories
{
    public class ApplicationUserGroupRepository : RepositoryBase<ApplicationUserGroup>, IApplicationUserGroupRepository
    {
        public ApplicationUserGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
