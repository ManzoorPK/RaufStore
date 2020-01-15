using Rauf_Gaming.Classes;
using Rauf_Gaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rauf_Gaming_Web.Controllers
{
    public class ConsoleController : Controller
    {
        // GET: Console
        public ActionResult Shop(string t, string m)
        {
            string search = "";
            if (Session["search"] != null)
            {
                search = Session["search"].ToString();
                Session["search"] = null;
            }
            Session["c"] = "Console";
            List<ProductV1> lst = null;
            if (t == null)
            {
                lst = new Games().GetProductList()
                       .Where(g => g.Type == "Console" && g.Category.Contains("PlayStation") && g.Condition == "New").ToList();
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
                            .Where(g => g.Type == "Console" && g.Category.Contains("PlayStation") && g.Condition == "New" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Console" && g.Category.Contains("PlayStation") && g.Condition == "New").ToList();
            }
            if (t == "u" && m == "ps")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Console" && g.Category.Contains("PlayStation") && g.Condition == "Used" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Console" && g.Category.Contains("PlayStation") && g.Condition == "Used").ToList();
            }
            if (t == "n" && m == "xbox")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Console" && g.Category.Contains("XBOX") && g.Condition == "New" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Console" && g.Category.Contains("XBOX") && g.Condition == "New").ToList();
            }
            if (t == "u" && m == "xbox")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Console" && g.Category.Contains("XBOX") && g.Condition == "Used" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Console" && g.Category.Contains("XBOX") && g.Condition == "Used").ToList();
            }
            if (t == "n" && m == "nintendo")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Console" && g.Category.Contains("Nintendo") && g.Condition == "New" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Console" && g.Category.Contains("Nintendo") && g.Condition == "New").ToList();
            }
            if (t == "u" && m == "nintendo")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Console" && g.Category.Contains("Nintendo") && g.Condition == "Used" &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Console" && g.Category.Contains("Nintendo") && g.Condition == "Used").ToList();
            }
            return View(lst);
        }
    }
}