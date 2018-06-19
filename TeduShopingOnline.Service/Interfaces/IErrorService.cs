using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IErrorService
    {
        Error CreatError(Error error);
        void Save();
    }
}
