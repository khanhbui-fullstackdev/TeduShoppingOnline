using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Web.Tests.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _postCategoryService;
        private List<PostCategory> _listPostCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _postCategoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory(){Id=1,Name="DM1",Status=true },
                new PostCategory(){Id=2,Name="DM2",Status=true },
                new PostCategory(){Id=3,Name="DM3",Status=true },
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {

        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {

        }

    }
}
