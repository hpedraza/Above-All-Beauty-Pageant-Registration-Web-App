using System.Web;
using System.Web.Optimization;

namespace Above_All_Beauty
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/Mine/carousel.js",
                        "~/Scripts/Mine/googleMaps.js",
                        "~/Scripts/Mine/SmoothScrolling.js",
                        "~/Scripts/Mine/add-participant.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/BootstrapOverwrite.css",
                      "~/Content/carousel.css",
                      "~/Content/add-participant.css",
                      "~/Content/payment.css",
                      "~/Content/event-details.css",
                      "~/Content/Account.css"));
        }
    }
}
