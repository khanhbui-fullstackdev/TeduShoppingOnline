using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TeduShopingOnline.Common.Constants;
using TeduShopingOnline.Common.Helpers;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Web.App_Start;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _userManager.Find(loginViewModel.UserName, loginViewModel.Password);
                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                    ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = loginViewModel.RememberMe;
                    authenticationManager.SignIn(props, identity);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User name or password incorrect.");
                }
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "RegisterCaptcha", "Incorrect capcha code")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userByEmail != null)
                {
                    ModelState.AddModelError("email", "This email has been existed in database");
                    return View(model);
                }
                var userByUserName = await _userManager.FindByNameAsync(model.UserName);
                if (userByUserName != null)
                {
                    ModelState.AddModelError("username", "This account has been existed in database");
                    return View(model);
                }
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    BirthDay = model.Birthday,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    IdentityNumber = model.IdentityNumber
                };

                await _userManager.CreateAsync(user, model.Password);

                var adminUser = await _userManager.FindByEmailAsync(model.Email);
                if (adminUser != null)
                    await _userManager.AddToRolesAsync(adminUser.Id, new string[] { "User" });

                string content = System.IO.File.ReadAllText(Server.MapPath(ViewUrls.EmailConfirmTemplate));
                content = content.Replace("{{UserName}}", adminUser.UserName);
                content = content.Replace("{{FullName}}", adminUser.FullName);
                content = content.Replace("{{Email}}", adminUser.Email);
                content = content.Replace("{{Link}}", ConfigHelper.GetByKey(CommonConstants.CurrentUrl) + "account/login");

                MailHelper.SendMail(adminUser.Email, "Your account has been registered successfully!", content);
                ViewData["SuccessMsg"] = "register successfully";
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Info()
        {
            return View();
        }

        public JsonResult GetAccountInfo()
        {
            // User has logined
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                var accountViewModel = new AccountInfoViewModel
                {
                    FullName = user.FullName,
                    IdentityNumber = user.IdentityNumber,
                    Email = user.Email,
                    Address = user.Address,
                    Birthday = user.BirthDay.Value.Date,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber
                };

                return Json(new
                {
                    status = true,
                    data = accountViewModel
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                status = false
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateAccountInfo(string accountInfoData)
        {
            var errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.IsAuthenticated)
                    {
                        var accountInfoViewModel = new JavaScriptSerializer().Deserialize<AccountInfoViewModel>(accountInfoData);
                        var userId = User.Identity.GetUserId();
                        var applicationUser = _userManager.FindById(userId);

                        if (applicationUser != null)
                        {
                            applicationUser.FullName = accountInfoViewModel.FullName;
                            applicationUser.Address = accountInfoViewModel.Address;
                            applicationUser.BirthDay = accountInfoViewModel.Birthday;
                            applicationUser.Email = accountInfoViewModel.Email;
                            applicationUser.UserName = accountInfoViewModel.UserName;
                            applicationUser.IdentityNumber = accountInfoViewModel.IdentityNumber;
                            applicationUser.PhoneNumber = accountInfoViewModel.PhoneNumber;
                            await _userManager.UpdateAsync(applicationUser);
                        }
                        return Json(new
                        {
                            status = true,
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.InnerException.Message;
            }
            return Json(new
            {
                status = false,
                error = errorMessage
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Changepassword(string userName)
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ChangePassword(string passwordInfo)
        {
            string errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    var passwordViewModel = new JavaScriptSerializer().Deserialize<PasswordViewModel>(passwordInfo);
                    ApplicationUser applicationUser = null;
                    string userId = string.Empty;

                    if (Request.IsAuthenticated)
                    {
                        userId = User.Identity.GetUserId();
                        applicationUser = _userManager.FindById(userId);
                    }
                    else
                    {
                        applicationUser = _userManager.FindByName(passwordViewModel.UserName);
                        userId = applicationUser.Id;
                    }
                    if (applicationUser != null)
                    {
                        if (!string.IsNullOrEmpty(passwordViewModel.NewPassword) &&
                            !string.IsNullOrEmpty(passwordViewModel.OldPassword) &&
                            !string.IsNullOrEmpty(passwordViewModel.RepeatNewPassword))
                        {
                            bool checkOldPassword = await _userManager.CheckPasswordAsync(applicationUser, passwordViewModel.OldPassword);
                            if (checkOldPassword == false)
                            {
                                errorMessage = "Your old password is incorrect, please try again!";
                                return Json(new
                                {
                                    status = false,
                                    error = errorMessage
                                }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                await _userManager.ChangePasswordAsync(userId, passwordViewModel.OldPassword, passwordViewModel.NewPassword);                                
                                return Json(new
                                {
                                    status = true,
                                }, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.InnerException.Message;
            }
            return Json(new
            {
                status = false,
                error = errorMessage
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GeneratePassword(string accountInfo)
        {
            string errorMessage = string.Empty;
            var accountInfoViewModel = new JavaScriptSerializer().Deserialize<AccountInfoViewModel>(accountInfo);
            try
            {
                if (ModelState.IsValid)
                {
                    if (!Request.IsAuthenticated)
                    {
                        if (accountInfo != null)
                        {
                            var userName = accountInfoViewModel.UserName;
                            var userEmail = accountInfoViewModel.Email;

                            var userByUserName = await _userManager.FindByNameAsync(userName);
                            var userByEmail = await _userManager.FindByEmailAsync(userEmail);
                            if (userByEmail == null || userByUserName == null)
                            {
                                errorMessage = "We cannot find your email or user name in system. Please try again!";
                                return Json(new
                                {
                                    error = errorMessage,
                                    status = false
                                }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                if (userByUserName.Id != userByEmail.Id)
                                {
                                    errorMessage = "Your user name and email must be consistent";
                                    return Json(new
                                    {
                                        error = errorMessage,
                                        status = false
                                    }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    string generatePassword = PasswordHelper.GeneratePassword(12);
                                    await _userManager.RemovePasswordAsync(userByUserName.Id);
                                    await _userManager.AddPasswordAsync(userByUserName.Id, generatePassword);

                                    string content = System.IO.File.ReadAllText(Server.MapPath(ViewUrls.GeneratePasswordTemplate));
                                    content = content.Replace("{{FullName}}", userByUserName.FullName);
                                    content = content.Replace("{{UserName}}", userByUserName.UserName);
                                    content = content.Replace("{{IdentityNumber}}", userByUserName.IdentityNumber);
                                    content = content.Replace("{{PhoneNumber}}", userByUserName.PhoneNumber);
                                    content = content.Replace("{{Email}}", userByUserName.Email);
                                    content = content.Replace("{{Address}}", userByUserName.Address);
                                    content = content.Replace("{{Password}}", generatePassword);
                                    MailHelper.SendMail(userByUserName.Email, "Forgot password", content);
                                    return Json(new
                                    {
                                        status = true,
                                        userName = userByUserName.UserName
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return Json(new
            {
                error = errorMessage
            }, JsonRequestBehavior.AllowGet);
        }
    }
}