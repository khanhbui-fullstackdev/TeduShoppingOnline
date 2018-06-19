using System.Collections.Generic;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory AddPostCategory(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public void DeletePostCategory(PostCategory postCategory)
        {
            _postCategoryRepository.Delete(postCategory);
        }

        public void DeletePostCategory(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAllPostCategory()
        {
            return _postCategoryRepository.GetAll();
        }

        public PostCategory GetPostCategoryById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<PostCategory> GetAllPostCategoryByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentId == parentId);
        }

        public void SavePostCategory()
        {
            _unitOfWork.Commit();
        }

        public void UpdatePostCategory(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}
