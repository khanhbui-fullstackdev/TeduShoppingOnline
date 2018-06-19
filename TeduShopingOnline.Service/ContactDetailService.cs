using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class ContactDetailService: IContactDetailService
    {
        private IContactDetailRepository _contactDetailRepository;
        private IUnitOfWork _unitOfWork;
        
        public ContactDetailService(IContactDetailRepository contactDetailRepository, IUnitOfWork unitOfWork)
        {
            this._contactDetailRepository = contactDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public ContactDetail GetDefaultContactDetail()
        {
            return _contactDetailRepository.GetSingleByCondition(x => x.Status);
        }
    }
}
