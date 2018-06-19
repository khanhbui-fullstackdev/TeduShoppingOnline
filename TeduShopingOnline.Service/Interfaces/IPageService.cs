using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IPageService
    {
        Page GetPageByAlias(string alias);
    }
}
