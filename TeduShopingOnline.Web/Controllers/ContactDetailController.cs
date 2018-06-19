using AutoMapper;
using System.Web.Mvc;
using System.IO;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;
using TeduShopingOnline.Web.ViewModels;
using BotDetect.Web.Mvc;
using System.Data.Entity.Validation;
using TeduShopingOnline.Common.Helpers;
using System;
using TeduShopingOnline.Web.Infrastructure.Extensions;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Web.Controllers
{
    public class ContactDetailController : Controller
    {
        private IContactDetailService _contactDetailService;
        private IFeedBackService _feedBackService;

        public ContactDetailController(IContactDetailService contactDetailService, IFeedBackService feedBackService)
        {
            this._contactDetailService = contactDetailService;
            this._feedBackService = feedBackService;
        }

        // GET: ContactDetail
        public ActionResult Index()
        {
            FeedBackViewModel feedBackViewModel = new FeedBackViewModel();
            feedBackViewModel.ContactDetailViewModel = GetDefaultContact();
            return View(feedBackViewModel);
        }

        private ContactDetailViewModel GetDefaultContact()
        {
            var contactDetailModel = _contactDetailService.GetDefaultContactDetail();
            var contactDetailViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(contactDetailModel);
            return contactDetailViewModel;
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ContactDetailCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult SendFeedBack(FeedBackViewModel feedBackViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FeedBack feedBack = new FeedBack();
                    feedBack.UpdateFeedback(feedBackViewModel);
                    _feedBackService.AddFeedBack(feedBack);
                    _feedBackService.SaveChanges();

                    ViewBag.SuccessMessage = "Your request has been sent to us";

                    string emailContent = System.IO.File.ReadAllText(Server.MapPath(ViewUrls.ContactTemplate));
                    emailContent = emailContent.Replace("{{Name}}", feedBackViewModel.Name);
                    emailContent = emailContent.Replace("{{Email}}", feedBackViewModel.Email);
                    emailContent = emailContent.Replace("{{Message}}", feedBackViewModel.Message);

                    string adminEmail = ConfigHelper.GetByKey(CommonConstants.AdminEmail);
                    MailHelper.SendMail(adminEmail, "Contact info from website", emailContent);

                    feedBackViewModel.Name = string.Empty;
                    feedBackViewModel.Message = string.Empty;
                    feedBackViewModel.Email = string.Empty;
                }
                feedBackViewModel.ContactDetailViewModel = GetDefaultContact();
                return View("Index", feedBackViewModel);
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw new Exception(raise.Message);
            }
        }
    }
}