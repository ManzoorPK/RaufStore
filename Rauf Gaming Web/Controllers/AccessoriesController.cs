using Rauf_Gaming.Classes;
using Rauf_Gaming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rauf_Gaming_Web.Controllers
{
    public class AccessoriesController : Controller
    {
        // GET: Accessories
        public ActionResult Shop(string t, string m)
        {
            string search = "";
            if (Session["search"] != null)
            {
                search = Session["search"].ToString();
                Session["search"] = null;
            }
            Session["c"] = "Acc";
            List<ProductV1> lst = null;
            if (t == null)
            {
                lst = new Games().GetProductList()
                       .Where(g => g.Type == "Acc" && g.Category.Contains("VR")).ToList();
                Session["t"] = "n";
                Session["m"] = "Acc";
            }
            else
            {
                Session["t"] = t;
                Session["m"] = m;
            }
            if (t == "vr")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("VR") &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                        .Where(g => g.Type == "Acc" && g.Category.Contains("VR")).ToList();
            }
            if (t == "tv")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("TV") &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                       .Where(g => g.Type == "Acc" && g.Category.Contains("TV")).ToList();
            }
            if (t == "hs")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("Headsets") &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                         .Where(g => g.Type == "Acc" && g.Category.Contains("Headsets")).ToList();
            }
            if (t == "ms")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("Mouse") &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                          .Where(g => g.Type == "Acc" && g.Category.Contains("Mouse")).ToList();
            }
            if (t == "js")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("Joysticks") &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                         .Where(g => g.Type == "Acc" && g.Category.Contains("Joysticks")).ToList();
            }
            if (t == "kb")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("Keyboards") &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Acc" && g.Category.Contains("Keyboards")).ToList();
            }
            if (t == "cm")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("Cameras") &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Acc" && g.Category.Contains("Cameras")).ToList();
            }
            if (t == "sp")
            {
                if (search != "")
                    lst = new Games().GetProductList()
                            .Where(g => g.Type == "Acc" && g.Category.Contains("Speakers") &&
                            (g.Title.Contains(search) || g.Platform.Contains(search))).ToList();
                else
                    lst = new Games().GetProductList()
                           .Where(g => g.Type == "Acc" && g.Category.Contains("Speakers")).ToList();
            }
            return View(lst);
        }
    }
}