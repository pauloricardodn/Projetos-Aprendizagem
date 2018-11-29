using System.Web;
using System.Web.Optimization;

namespace Administracao.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                      "~/Scripts/Chosen/chosen.jquery.minjs",
                      "~/Scripts/Chosen/chosen.proto.minjs"));

            bundles.Add(new StyleBundle("~/Content/Chosen").Include(
                      "~/Content/Chosen/chosen.min.css",
                      "~/Content/Chosen/docsupport/prism.css",
                      "~/Content/Chosen/docsupport/style.css",
                      "~/Content/Chosen/docsupport/prism.js"
                      ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Modal.css",
                      "~/Content/site.css"));
        }
    }
}
