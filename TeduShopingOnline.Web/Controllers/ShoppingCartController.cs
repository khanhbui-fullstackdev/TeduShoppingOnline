using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TeduShopingOnline.Common.Constants;
using TeduShopingOnline.Common.Helpers;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;
using TeduShopingOnline.Web.App_Start;
using TeduShopingOnline.Web.Infrastructure.Extensions;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductService _productService;
        private ApplicationUserManager _userManager;
        private IOrderService _orderService;

        public ShoppingCartController(
            IProductService productService,
            ApplicationUserManager userManager,
            IOrderService orderService)
        {
            this._productService = productService;
            this._userManager = userManager;
            this._orderService = orderService;
        }

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = Session[CommonConstants.SessionCart];
            if (cart == null)
                cart = new List<ShoppingCartViewModel>();
            return View();
        }

        /// <summary>
        /// Get all items in cart
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllItemsInCart()
        {
            var cart = Session[CommonConstants.SessionCart];
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
                return Json(new
                {
                    data = cart,
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Add new product to cart
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(int productId)
        {
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            var product = _productService.GetProductDetail(productId);
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }
            if (product.Quantity == 0)
            {
                return Json(new
                {
                    status = false,
                    message = "This product doesn't exist in database"
                });
            }
            if (cart.Any(x => x.ProductId == productId))
            {
                foreach (var item in cart)
                {
                    if (item.ProductId == productId)
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductId = productId;
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }        
            Session[CommonConstants.SessionCart] = cart;
            return Json(new
            {
                status = true
            });
        }

        /// <summary>
        /// Update cart item on Session
        /// </summary>
        /// <param name="cartData"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateCart(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];

            foreach (var item in cartSession)
            {
                foreach (var jitem in cartViewModel)
                {
                    if (item.ProductId == jitem.ProductId)
                    {
                        item.Quantity = jitem.Quantity;
                    }
                }
            }

            Session[CommonConstants.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        /// <summary>
        /// Delete all items in cart
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            return Json(new
            {
                status = true
            });
        }

        /// <summary>
        /// Delete item in cart
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteItem(int productId)
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if (cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductId == productId);
                Session[CommonConstants.SessionCart] = cartSession;
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Payment()
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if (cartSession != null)
            {
                RedirectToAction("Index", "ShoppingCart");
            }
            return View();
        }

        public JsonResult GetUserInfo()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                return Json(new
                {
                    data = user,
                    status = true,
                });
            }
            return Json(new
            {
                status = false,
            });
        }

        public JsonResult CreateOrder(string orderViewModel)
        {
            try
            {
                var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
                var newOrder = new Order();
                newOrder.UpdateOrder(order);

                if (Request.IsAuthenticated)// User is login
                {
                    newOrder.CustomerId = User.Identity.GetUserId();
                    newOrder.CreatedBy = User.Identity.GetUserName();

                    ApplicationUser applicationUser = new ApplicationUser();
                    applicationUser.IdentityNumber = newOrder.CustomerIdentityNumber;
                    applicationUser.PhoneNumber = newOrder.CustomerMobile;
                    _userManager.Update(applicationUser);
                }

                var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
                var orderDetails = new List<OrderDetail>();
                foreach (var cartItem in cartSession)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = cartItem.ProductId;
                    orderDetail.Quantity = cartItem.Quantity;
                    orderDetail.Price = cartItem.Product.Price.Value;
                    orderDetails.Add(orderDetail);
                }
                _orderService.CreateOrder(newOrder, orderDetails);
                bool sendOk = SendEmail(newOrder, cartSession);

                return Json(new
                {
                    status = true,
                    mailStatus = sendOk
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    error = ex.Message
                });
                throw new Exception(ex.Message);
            }
        }

        public JsonResult CreateOrderAndSendEmail(string orderViewModel)
        {
            try
            {
                var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
                var newOrder = new Order();
                newOrder.UpdateOrder(order);

                if (Request.IsAuthenticated)// User is login
                {
                    newOrder.CustomerId = User.Identity.GetUserId();
                    newOrder.CreatedBy = User.Identity.GetUserName();

                    ApplicationUser applicationUser = new ApplicationUser();
                    applicationUser.IdentityNumber = newOrder.CustomerIdentityNumber;
                    applicationUser.PhoneNumber = newOrder.CustomerMobile;
                    _userManager.Update(applicationUser);
                }

                var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
                var orderDetails = new List<OrderDetail>();
                foreach (var cartItem in cartSession)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = cartItem.ProductId;
                    orderDetail.Quantity = cartItem.Quantity;
                    orderDetail.Price = cartItem.Product.Price.Value;
                    orderDetails.Add(orderDetail);
                }
                _orderService.CreateOrder(newOrder, orderDetails);

                return Json(new
                {
                    status = true,
                    orderInfo = newOrder,
                    cartItems = cartSession
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    error = ex.Message
                });
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendEmail(string emailContentViewModel)
        {
            try
            {
                //var emailContent = new JavaScriptSerializer().Deserialize<string>(emailContentViewModel);
                //MailHelper.SendMail(adminUser.Email, "Your account has been registered successfully!", content);
                if (!string.IsNullOrEmpty(emailContentViewModel))

                    return Json(new
                    {
                        status = true
                    });
                return Json(new
                {
                    status = false
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SendEmail(Order order, List<ShoppingCartViewModel> orderDetails)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                string customerInfoContent = System.IO.File.ReadAllText(Server.MapPath(ViewUrls.CustomerInfoTemplate));
                customerInfoContent = customerInfoContent.Replace("{{FullName}}", order.CustomerName);
                customerInfoContent = customerInfoContent.Replace("{{UserName}}", order.CreatedBy);
                customerInfoContent = customerInfoContent.Replace("{{IdentityNumber}}", order.CustomerIdentityNumber);
                customerInfoContent = customerInfoContent.Replace("{{PhoneNumber}}", order.CustomerMobile);
                customerInfoContent = customerInfoContent.Replace("{{Email}}", order.CustomerEmail);
                customerInfoContent = customerInfoContent.Replace("{{Address}}", order.CustomerAddress);

                string tHeadOrderDetailContent = System.IO.File.ReadAllText(Server.MapPath(ViewUrls.THeadOrderDetailTemplate));
                string tRowOrderDetailTotalContent = System.IO.File.ReadAllText(Server.MapPath(ViewUrls.TRowOrderDetailTotalTemplate));

                decimal totalOrder = 0;
                string tRowOrderDetailContent = string.Empty;
                string temp = string.Empty;

                foreach (var orderDetail in orderDetails)
                {
                    string tRowOrderDetailContentTemp = System.IO.File.ReadAllText(Server.MapPath(ViewUrls.TRowOrderDetailTemplate));
                    tRowOrderDetailContentTemp = tRowOrderDetailContentTemp.Replace("{{OrderId}}", order.ID.ToString());
                    tRowOrderDetailContentTemp = tRowOrderDetailContentTemp.Replace("{{ProductId}}", orderDetail.ProductId.ToString());
                    tRowOrderDetailContentTemp = tRowOrderDetailContentTemp.Replace("{{ProductName}}", orderDetail.Product.Name);
                    tRowOrderDetailContentTemp = tRowOrderDetailContentTemp.Replace("{{Quantity}}", orderDetail.Quantity.ToString());
                    tRowOrderDetailContentTemp = tRowOrderDetailContentTemp.Replace("{{Price}}", string.Format("{0:0,0}₫", orderDetail.Product.Price));
                    tRowOrderDetailContentTemp = tRowOrderDetailContentTemp.Replace("{{Total}}", string.Format("{0:0,0}₫", orderDetail.Product.Price.Value * orderDetail.Quantity));
                    totalOrder += orderDetail.Product.Price.Value * orderDetail.Quantity;
                    tRowOrderDetailContent += tRowOrderDetailContentTemp;
                }
                tRowOrderDetailTotalContent = tRowOrderDetailTotalContent.Replace("{{Sum}}", string.Format("{0:0,0}₫", totalOrder));
                stringBuilder
                    .Append(customerInfoContent)
                    .Append("<table border='1' style='border - collapse:collapse'>")
                    .Append(tHeadOrderDetailContent)
                    .Append("<tbody>")
                    .Append(tRowOrderDetailContent)
                    .Append(tRowOrderDetailTotalContent)
                    .Append("</tbody></table>");
                MailHelper.SendMail(order.CustomerEmail, "Your order detail information", stringBuilder.ToString());
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
    }
}