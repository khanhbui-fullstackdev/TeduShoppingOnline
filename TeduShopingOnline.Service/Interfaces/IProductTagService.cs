using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IProductTagService
    {
        IEnumerable<Tag> GetTagsByProductId(int productId);
    }
}
