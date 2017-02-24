using System.Web;
using System.Web.Optimization;

namespace Gapura
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.2.4.js",
                        "~/Scripts/js/bootstrap.min.js",
                        "~/Scripts/js/jquery.*"
                        //"~/Scripts/js/jquery-ui-1.10.0.custom.min.js",
                        //"~/Scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        //"~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/js/jquery-ui-1.10.0.custom.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"
            ));

            //bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
            //            "~/Scripts/jquery.unobtrusive*"
            //));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                    //"~/Scripts/js/bootstrap.js",  //Conflict with  dataTables.bootstrap.js
                    "~/Scripts/js/counter.js",
                    "~/Scripts/js/custom.js",
                    "~/Scripts/js/excanvas.js",
                    "~/Scripts/js/jquery.cookie.js",
                    "~/Scripts/js/jquery.flot.js",
                    "~/Scripts/js/jquery.flot.pie.js",
                    "~/Scripts/js/jquery.flot.stack.js",
                    "~/Scripts/js/jquery.imagesloaded.js",
                    "~/Scripts/js/jquery.iphone.toggle.js",
                    "~/Scripts/js/jquery.knob.modified.js",
                    "~/Scripts/js/jquery.noty.js",
                    "~/Scripts/js/jquery.ui.touch-punch.js",                
                    "~/Scripts/js/retina.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-2.1.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTablesLayout").Include(
                    "~/Scripts/dataTables/jquery.dataTables.js",
                    "~/Scripts/dataTables/dataTables.bootstrap.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                    //"~/Scripts/dataTables/jquery.dataTables.js",          // Already On ~/bundles/dataTablesLayout
                    //"~/Scripts/dataTables/dataTables.bootstrap.min.js",
                    //"~/Scripts/dataTables/dataTables.buttons.min.js",
                    //"~/Scripts/dataTables/dataTables.select.min.js"
                    //,"~/Scripts/dataTables/dataTables.editor.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/min").Include(               
                "~/Scripts/js/fullcalendar.min.js",
                "~/Scripts/js/jquery-migrate-1.0.0.min.js",
                "~/Scripts/js/jquery.chosen.min.js",
                "~/Scripts/js/jquery.cleditor.min.js",
                "~/Scripts/js/jquery.elfinder.min.js",
                "~/Scripts/js/jquery.flot.resize.min.js",
                "~/Scripts/js/jquery.gritter.min.js",
                "~/Scripts/js/jquery.masonry.min.js",
                "~/Scripts/js/jquery.raty.min.js",
                "~/Scripts/js/jquery.sparkline.min.js",
                "~/Scripts/js/jquery.uniform.min.js",                         
                "~/Scripts/js/jquery.uploadify-3.1.min.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/dataTables").Include(
                        "~/Content/dataTables/jquery.dataTables.min.css",
                        //"~/Content/dataTables/buttons.dataTables.min.css",
                        "~/Content/dataTables/select.dataTables.min.css"
                        //"~/Content/dataTables/editor.dataTables.min.css"
            ));

            bundles.Add(new StyleBundle("~/Content/main").Include(
                        "~/Content/css/bootstrap.min.css",
                        "~/Content/css/bootstrap-responsive.min.css",
                        "~/Content/css/style.css",
                        "~/Content/css/style-responsive.css",
                        "~/Content/css/font.css"
            ));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}