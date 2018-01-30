using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchLibrary.Models;

namespace SearchLibrary.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new QueryResponse();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string searchText)
        {
            //SolrHelper.ReIndexAllCourses();
            ViewBag.SearchText = searchText;


            CourseSearch search = new CourseSearch();

            CourseQuery query = new CourseQuery();

            query.Query = searchText;

            var model = search.DoSearch(query);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}