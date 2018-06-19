using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IPostCategoryService
    {
        PostCategory AddPostCategory(PostCategory postCategory);
        void UpdatePostCategory(PostCategory postCategory);
        void DeletePostCategory(PostCategory postCategory);
        void DeletePostCategory(int id);
        void SavePostCategory();

        IEnumerable<PostCategory> GetAllPostCategory();
        IEnumerable<PostCategory> GetAllPostCategoryByParentId(int parentId);
        PostCategory GetPostCategoryById(int id);
    }
}
