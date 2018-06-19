using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service
{
    public class BrandService : IBrandService
    {
        private IBrandRepository _brandRepository;
        private IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository brandRepository,IUnitOfWork unitOfWork)
        {
            this._brandRepository = brandRepository;
            this._unitOfWork = unitOfWork;
        }

        public Brand GetBrandById(int brandId)
        {
            return _brandRepository.GetSingleById(brandId);
        }

        public IEnumerable<Brand> GetTopBrand()
        {
            return _brandRepository.GetTopBrand();
        }
    }
}
