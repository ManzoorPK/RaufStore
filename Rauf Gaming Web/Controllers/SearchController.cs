using Rauf_Gaming.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rauf_Gaming_Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public PartialViewResult Search()
        {
            return PartialView("_Search");
        }
        [HttpPost]
        public JsonResult DoSearch(string searchText)
        {
            Session["search"] = searchText;
            return Json(Session["c"].ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}