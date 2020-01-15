using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rauf_Gaming.Classes;
using Rauf_Gaming.Models;

namespace Rauf_Gaming_Web.Controllers
{
    public class GameController : Controller
    {
        // GET: Game

        public ActionResult Shop(string t, string m)
        {
            string search = "";
            if (Session["search"] != null)
            {
                search = Session["search"].ToString();
                Session["search"] = null;
            }
            Session["c"] = "Game";
            List<ProductV1> lst = null;
            if (t == null)
            {

                lst = new Games().GetProductList()
                       .Where(g => g.Type == "Game" && g.Platform.Contains("Ps") && g.Condition == "New").ToList();
                Session["t"] = "n";
                Session["m"] = "ps";
            }
            else
            {
                Session["t"] = t;
                Session["m"] = m;
            }
            if (t == "n" && m == "ps")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Game" && g.Platform.Contains("Ps") && g.Condition == "New" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("Ps") && g.Condition == "New").ToList();
            }
            if (t == "u" && m == "ps")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Game" && g.Platform.Contains("Ps") && g.Condition == "Used" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("Ps") && g.Condition == "Used").ToList();
            }
            if (t == "n" && m == "xbox")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Game" && g.Platform.Contains("XBox") && g.Condition == "New" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Game" && g.Platform.Contains("XBox") && g.Condition == "New").ToList();
            }
            if (t == "u" && m == "xbox")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Game" && g.Platform.Contains("XBox") && g.Condition == "Used" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Game" && g.Platform.Contains("XBox") && g.Condition == "Used").ToList();
            }
            if (t == "n" && m == "nintendo")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Game" && g.Platform.Contains("Nintendo") && g.Condition == "New" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Game" && g.Platform.Contains("Nintendo") && g.Condition == "New").ToList();
            }
            if (t == "u" && m == "nintendo")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Game" && g.Platform.Contains("Nintendo") && g.Condition == "Used" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Game" && g.Platform.Contains("Nintendo") && g.Condition == "Used").ToList();
            }


            return View(lst);
        }

        public ActionResult ProductDetail(int Id)
        {
            Session["c"] = "Game";
            var product = new Games().GetProductList().Where(g => g.ProductId == Id).FirstOrDefault();
            return View(product);

        }
        public PartialViewResult NewGames()
        {
            List<ProductV1> lst = null;
            List<ProductV1> latestGames = new List<ProductV1>();

            lst = new Games().GetProductList()
                      .Where(g => g.Type == "Game" && g.Condition == "New").Take(6).ToList();
            return PartialView("_NewGames", lst);
        }
        public PartialViewResult RelatedProducts()
        {
            string t = "";
            string m = "";
            string type = "";
            if (Session["t"] != null)
            {
                t = Session["t"].ToString();
            }
            if (Session["m"] != null)
            {
                m = Session["m"].ToString();
            }
            List<ProductV1> lst = null;
            if (Session["c"] != null)
            {
                type = Session["c"].ToString();
            }
            else
            {
                type = "Game";
                
               
            }
            if (t != "" && m == "")
            {
                type = "Acc";
            }
            if (type == "Game")
            {
                if (t == "")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("Ps") && g.Condition == "New").Take(3).ToList();
                }
                if (t == "n" && m == "ps")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("Ps") && g.Condition == "New").Take(3).ToList();
                }
                if (t == "u" && m == "ps")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("Ps") && g.Condition == "Used").Take(3).ToList();
                }
                if (t == "n" && m == "xbox")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("XBox") && g.Condition == "New").Take(3).ToList();
                }
                if (t == "u" && m == "xbox")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("XBox") && g.Condition == "Used").Take(3).ToList();
                }
                if (t == "n" && m == "nintendo")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("Nintendo") && g.Condition == "New").Take(3).ToList();
                }
                if (t == "u" && m == "nintendo")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Game" && g.Platform.Contains("Nintendo") && g.Condition == "Used").Take(3).ToList();
                }
            }
            if (type == "Acc")
            {

                if (t == "vr")
                {
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("VR")).ToList();
                }
                if (t == "tv")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Acc" && g.Category.Contains("TV")).ToList();
                }
                if (t == "hs")
                {
                    lst = new Games().GetProductList()
                             .Where(g => g.Type == "Acc" && g.Category.Contains("Headsets")).ToList();
                }
                if (t == "ms")
                {
                    lst = new Games().GetProductList()
                              .Where(g => g.Type == "Acc" && g.Category.Contains("Mouse")).ToList();
                }
                if (t == "js")
                {
                    lst = new Games().GetProductList()
                             .Where(g => g.Type == "Acc" && g.Category.Contains("Joysticks")).ToList();
                }
                if (t == "kb")
                {
                    lst = new Games().GetProductList()
                               .Where(g => g.Type == "Acc" && g.Category.Contains("Keyboards")).ToList();
                }
                if (t == "cm")
                {
                    lst = new Games().GetProductList()
                               .Where(g => g.Type == "Acc" && g.Category.Contains("Cameras")).ToList();
                }
                if (t == "sp")
                {
                    lst = new Games().GetProductList()
                               .Where(g => g.Type == "Acc" && g.Category.Contains("Speakers")).ToList();
                }
            }

            if (type == "Console")
            {
                if (t == "n" && m == "ps")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Console" && g.Category.Contains("PlayStation") && g.Condition == "New").ToList();
                }
                if (t == "u" && m == "ps")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Console" && g.Category.Contains("PlayStation") && g.Condition == "Used").ToList();
                }
                if (t == "n" && m == "xbox")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Console" && g.Category.Contains("XBOX") && g.Condition == "New").ToList();
                }
                if (t == "u" && m == "xbox")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Console" && g.Category.Contains("XBOX") && g.Condition == "Used").ToList();
                }
                if (t == "n" && m == "nintendo")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Console" && g.Category.Contains("Nintendo") && g.Condition == "New").ToList();
                }
                if (t == "u" && m == "nintendo")
                {
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Console" && g.Category.Contains("Nintendo") && g.Condition == "Used").ToList();
                }
            }
            return PartialView("_RelatedProducts", lst);
        }
    }
}