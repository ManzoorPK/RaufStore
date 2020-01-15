using Rauf_Gaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rauf_Gaming_Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ChangeLng(string Lang)
        {
            Session["lng"] = Lang;
            return Json(Session["lng"].ToString(), JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult Slider()
        {
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.SliderVs.OrderByDescending(o=> o.ProductId).ToList();
                return PartialView("_Slider", lst);
            }
        }
    }
}