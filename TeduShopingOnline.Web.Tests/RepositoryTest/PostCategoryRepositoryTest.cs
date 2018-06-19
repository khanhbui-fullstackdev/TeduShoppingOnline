using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Web.Tests.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory _dbFactory;
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _postCategoryRepository = new PostCategoryRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);

        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var postCategories = _postCategoryRepository.GetAll();
            Assert.AreEqual(3,postCategories.Count());
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "Test post category";
            postCategory.Alias = "Test-post-category";
            postCategory.Status = true;

            var result = _postCategoryRepository.Add(postCategory);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
    }
}
