using System;
using System.Collections.Generic;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class TagService : ITagService
    {
        private ITagRepository _tagRepository;
        private IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tag GetTagByTagId(string tagId)
        {
            return _tagRepository.GetSingleByCondition(x => x.ID == tagId);
        }

        public IEnumerable<Tag> GetTagsByProductId(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
