using System.Web.Mvc;
using System.Web.Routing;

namespace TeduShopingOnline.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces:new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            //BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            // Ex: product-category/perfume/5
            routes.MapRoute(
                name: "Product Category",
                url: "product-category/{alias}/{productCategoryId}",
                defaults: new { controller = "Product", action = "ProductsByProductCategory", productCategoryId = UrlParameter.Optional },
                namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Product Brand",
                url: "brand/{brandName}/{brandId}",
                defaults: new { controller = "Product", action = "ProductsByBrand", brandId = UrlParameter.Optional },
                namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Product By Gender",
                url: "products/gender/{gender}",
                defaults: new { controller = "Product", action = "ProductsByGender", gender = UrlParameter.Optional },
                namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Product",
                url: "products",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "product-detail/{alias}/{id}",
                defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
                namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Tag",
               url: "tag/{tagId}",
               defaults: new { controller = "Product", action = "ProductsByTag", keyword = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Search",
               url: "search-result",
               defaults: new { controller = "Product", action = "SearchResult", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Page",
               url: "page/{alias}",
               defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Contact Detail",
               url: "contact",
               defaults: new { controller = "ContactDetail", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Register",
               url: "account/register",
               defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Info",
               url: "account/info",
               defaults: new { controller = "Account", action = "Info", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Login",
               url: "account/login",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Forgot Password",
               url: "account/forgot-password",
               defaults: new { controller = "Account", action = "ForgotPassword", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Change Password",
               url: "account/change-password/user-name/{userName}",
               defaults: new { controller = "Account", action = "Changepassword", userName = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Shopping Cart",
               url: "cart",
               defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Payment",
               url: "payment",
               defaults: new { controller = "Payment", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TeduShopingOnline.Web.Controllers" }
            );

            // Default route should be located at the last line
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
