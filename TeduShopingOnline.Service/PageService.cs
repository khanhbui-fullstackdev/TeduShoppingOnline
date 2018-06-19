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
    public class PageService : IPageService
    {
        IPageRepository _pageRepository;
        IUnitOfWork _unitOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._pageRepository = pageRepository;
        }

        public Page GetPageByAlias(string alias)
        {
            return _pageRepository.GetSingleByCondition(x => x.Alias.ToLower().Equals(alias.ToLower()));
        }
    }
}
