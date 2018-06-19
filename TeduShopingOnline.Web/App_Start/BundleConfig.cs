using System.Web;
using System.Web.Optimization;
using TeduShopingOnline.Common.Helpers;

namespace TeduShopingOnline.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/Assets/Client/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                 "~/Assets/Client/js/common.js"
                ));
            bundles.Add(new StyleBundle("~/css/base")
                .Include("~/Assets/Client/css/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/font-awesome-4.6.3/css/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/custom.css", new CssRewriteUrlTransform())
                );
            BundleTable.EnableOptimizations = bool.Parse(ConfigHelper.GetByKey("EnableBundles"));
        }
    }
}