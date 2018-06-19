using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IFeedBackService
    {
        void SaveChanges();
        FeedBack AddFeedBack(FeedBack feedBack);
    }
}
