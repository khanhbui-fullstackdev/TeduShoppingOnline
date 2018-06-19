using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class FeedBackService : IFeedBackService
    {
        IFeedBackRepository _feedBackRepository;
        IUnitOfWork _unitOfWork;

        public FeedBackService(IFeedBackRepository feedBackRepository, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._feedBackRepository = feedBackRepository;
        }

        public FeedBack AddFeedBack(FeedBack feedBack)
        {
            return _feedBackRepository.Add(feedBack);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
