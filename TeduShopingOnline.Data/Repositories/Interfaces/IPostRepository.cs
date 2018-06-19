using System.Collections.Generic;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }
}
