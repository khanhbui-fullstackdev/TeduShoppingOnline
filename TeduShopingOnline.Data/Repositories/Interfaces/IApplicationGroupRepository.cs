using System.Collections.Generic;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories.Interfaces
{
    public interface IApplicationGroupRepository : IRepository<ApplicationGroup>
    {
        IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId);
        IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId);
    }
}
