using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Tag> GetTagsByProductId(int productId);
        Tag GetTagByTagId(string tagId);
    }
}
