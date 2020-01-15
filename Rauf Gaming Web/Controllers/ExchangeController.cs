using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rauf_Gaming.Classes;
using Rauf_Gaming.Models;

namespace Rauf_Gaming_Web.Controllers
{
    public class ExchangeController : Controller
    {
        // GET: Exchange
        public ActionResult Exchange(string type)
        {
            Session["tt"] = type;
            using (var _Entity = new GamesEntities())
            {
                IEnumerable<SelectListItem> items = _Entity.Exchanges.Where(g => g.Platform.Contains(type)).Select(c => new SelectListItem
                {
                    Value = c.ExchangeId.ToString(),
                    Text = c.Title

                }).ToList();
                ViewBag.Games = items;
                return View();
            }
        }
        public ActionResult R()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DoExchange(int ClientGameId, int StoreGameId)
        {
            Exchange clientGame = new Exchange();
            Exchange storeGame = new Exchange();

            using (var _Entity = new GamesEntities())
            {
                clientGame = _Entity.Exchanges
                              .Where(g => g.ExchangeId == ClientGameId).FirstOrDefault();
                storeGame = _Entity.Exchanges
                              .Where(g => g.ExchangeId == StoreGameId).FirstOrDefault();
            }

            var payment = storeGame.StorePrice - clientGame.BuyingPrice;

            return Json(payment, JsonRequestBehavior.AllowGet);
        }
    }
}