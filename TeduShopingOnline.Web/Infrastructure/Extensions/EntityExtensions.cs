﻿using System;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Extention Method of class PostCategory 
        /// It must be static class and static method
        /// </summary>
        /// <param name="postCategory"></param>
        /// <param name="postCategoryViewModel"></param>
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.Id = postCategoryViewModel.Id;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Description = postCategoryViewModel.Description;
            postCategory.Alias = postCategoryViewModel.Alias;
            postCategory.ParentId = postCategoryViewModel.ParentId;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;

            postCategory.CreatedDate = postCategoryViewModel.CreatedDate;
            postCategory.CreatedBy = postCategoryViewModel.CreatedBy;
            postCategory.UpdatedDate = postCategoryViewModel.UpdatedDate;
            postCategory.UpdatedBy = postCategoryViewModel.UpdatedBy;
            postCategory.MetaKeywork = postCategoryViewModel.MetaKeywork;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.Status = postCategoryViewModel.Status;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
        {
            productCategory.Id = productCategoryVm.Id;
            productCategory.Name = productCategoryVm.Name;
            productCategory.Description = productCategoryVm.Description;
            productCategory.Alias = productCategoryVm.Alias;
            productCategory.ParentId = productCategoryVm.ParentId;
            productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
            productCategory.HomeFlag = productCategoryVm.HomeFlag;

            productCategory.CreatedDate = DateTime.Now.Date;
            productCategory.CreatedBy = string.IsNullOrEmpty(productCategoryVm.CreatedBy) == true ? "khanhbui" : productCategoryVm.CreatedBy;
            productCategory.UpdatedDate = productCategoryVm.UpdatedDate;
            productCategory.UpdatedBy = productCategoryVm.UpdatedBy;
            productCategory.MetaDescription = productCategoryVm.MetaDescription;
            productCategory.Status = productCategoryVm.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            //post.ID = postVm.ID;
            //post.Name = postVm.Name;
            //post.Description = postVm.Description;
            //post.Alias = postVm.Alias;
            //post.CategoryID = postVm.CategoryID;
            //post.Content = postVm.Content;
            //post.Image = postVm.Image;
            //post.HomeFlag = postVm.HomeFlag;
            //post.ViewCount = postVm.ViewCount;

            //post.CreatedDate = postVm.CreatedDate;
            //post.CreatedBy = postVm.CreatedBy;
            //post.UpdatedDate = postVm.UpdatedDate;
            //post.UpdatedBy = postVm.UpdatedBy;
            //post.MetaKeyword = postVm.MetaKeyword;
            //post.MetaDescription = postVm.MetaDescription;
            //post.Status = postVm.Status;
        }

        //public static void UpdateProduct(this Product product, ProductViewModel productVm)
        //{
        //    product.ID = productVm.ID;
        //    product.Name = productVm.Name;
        //    product.Description = productVm.Description;
        //    product.Alias = productVm.Alias;
        //    product.CategoryID = productVm.CategoryID;
        //    product.Content = productVm.Content;
        //    product.Image = productVm.Image;
        //    product.MoreImages = productVm.MoreImages;
        //    product.Price = productVm.Price;
        //    product.PromotionPrice = productVm.PromotionPrice;
        //    product.Warranty = productVm.Warranty;
        //    product.HomeFlag = productVm.HomeFlag;
        //    product.HotFlag = productVm.HotFlag;
        //    product.ViewCount = productVm.ViewCount;

        //    product.CreatedDate = productVm.CreatedDate;
        //    product.CreatedBy = productVm.CreatedBy;
        //    product.UpdatedDate = productVm.UpdatedDate;
        //    product.UpdatedBy = productVm.UpdatedBy;
        //    product.MetaKeyword = productVm.MetaKeyword;
        //    product.MetaDescription = productVm.MetaDescription;
        //    product.Status = productVm.Status;
        //    product.Tags = productVm.Tags;
        //    product.Quantity = productVm.Quantity;
        //    product.OriginalPrice = productVm.OriginalPrice;
        //}

        public static void UpdateFeedback(this FeedBack feedback, FeedBackViewModel feedbackVm)
        {
            feedback.Name = feedbackVm.Name;
            feedback.Email = feedbackVm.Email;
            feedback.Message = feedbackVm.Message;
            feedback.CreatedDate = DateTime.Now;
        }

        public static void UpdateOrder(this Order order, OrderViewModel orderVm)
        {
            order.CustomerName = orderVm.CustomerName;
            order.CustomerAddress = orderVm.CustomerAddress;
            order.CustomerEmail = orderVm.CustomerEmail;
            order.CustomerMobile = orderVm.CustomerMobile;
            order.CustomerMessage = orderVm.CustomerMessage;
            order.CustomerIdentityNumber = orderVm.CustomerIdentityNumber;
            order.PaymentMethod = orderVm.PaymentMethod;
            order.CreatedDate = DateTime.Now;
            order.CreatedBy = orderVm.CreatedBy;
            order.Status = orderVm.Status;
            order.CustomerId = orderVm.CustomerId;
            order.PaymentStatus = orderVm.PaymentStatus;
        }

        //public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        //{
        //    appGroup.ID = appGroupViewModel.ID;
        //    appGroup.Name = appGroupViewModel.Name;
        //}

        //public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        //{
        //    if (action == "update")
        //        appRole.Id = appRoleViewModel.Id;
        //    else
        //        appRole.Id = Guid.NewGuid().ToString();
        //    appRole.Name = appRoleViewModel.Name;
        //    appRole.Description = appRoleViewModel.Description;
        //}
        //public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        //{

        //    appUser.Id = appUserViewModel.Id;
        //    appUser.FullName = appUserViewModel.FullName;
        //    appUser.BirthDay = appUserViewModel.BirthDay;
        //    appUser.Email = appUserViewModel.Email;
        //    appUser.UserName = appUserViewModel.UserName;
        //    appUser.PhoneNumber = appUserViewModel.PhoneNumber;
        //}
    }
}