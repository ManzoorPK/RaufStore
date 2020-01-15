using Rauf_Gaming.Classes;
using Rauf_Gaming.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rauf_Gaming.Controllers
{
    public class AdminController : Controller
    {
        #region Dashboard
        public ActionResult Dashboard()
        {
            using (var _Entity = new GamesEntities())
            {
                Rauf_Gaming.Models.Dashboard dashboard = new Dashboard();

                dashboard.Orders = _Entity.Orders.ToList().Count;
                dashboard.Ps4New = _Entity.ProductV1.Where(p => p.Type == "Console" && 
                                    p.Category == "PlayStation" && p.Condition == "New").ToList().Count();
                dashboard.Ps4Used = _Entity.ProductV1.Where(p => p.Type == "Console" &&
                                   p.Category == "PlayStation" && p.Condition == "Used").ToList().Count();

                dashboard.XBoxNew = _Entity.ProductV1.Where(p => p.Type == "Console" &&
                                   p.Category == "XBOX" && p.Condition == "New").ToList().Count();

                dashboard.XBoxUsed = _Entity.ProductV1.Where(p => p.Type == "Console" &&
                                   p.Category == "XBOX" && p.Condition == "Used").ToList().Count();

                dashboard.NintendoNew = _Entity.ProductV1.Where(p => p.Type == "Console" &&
                                   p.Category == "Nintendo" && p.Condition == "New").ToList().Count();

                dashboard.NintendoUsed = _Entity.ProductV1.Where(p => p.Type == "Console" &&
                                   p.Category == "Nintendo" && p.Condition == "Used").ToList().Count();

                dashboard.Ps4NewGames = _Entity.ProductV1.Where(p => p.Type == "Game" &&
                                   p.Platform.Contains("Ps") && p.Condition == "New").ToList().Count();

                dashboard.Ps4UsedGames = _Entity.ProductV1.Where(p => p.Type == "Game" &&
                                   p.Platform.Contains("Ps") && p.Condition == "Used").ToList().Count();

                dashboard.XBoxNew = _Entity.ProductV1.Where(p => p.Type == "Game" &&
                                   p.Platform.Contains("XBox") && p.Condition == "New").ToList().Count();

                dashboard.XBoxUsed = _Entity.ProductV1.Where(p => p.Type == "Game" &&
                                   p.Platform.Contains("XBox") && p.Condition == "Used").ToList().Count();

                dashboard.NintendoNewGames = _Entity.ProductV1.Where(p => p.Type == "Game" &&
                                   p.Platform.Contains("Nintendo") && p.Condition == "New").ToList().Count();

                dashboard.NintendoUsedGames = _Entity.ProductV1.Where(p => p.Type == "Game" &&
                                   p.Platform.Contains("Nintendo") && p.Condition == "Used").ToList().Count();
                dashboard.VR = _Entity.ProductV1.Where(p => p.Type == "Acc" &&
                                   p.Category == "VR").ToList().Count();
                dashboard.TV = _Entity.ProductV1.Where(p => p.Type == "Acc" &&
                                   p.Category == "TV").ToList().Count();
                dashboard.HeadSet = _Entity.ProductV1.Where(p => p.Type == "Acc" &&
                                   p.Category == "Headsets").ToList().Count();
                dashboard.Mouse = _Entity.ProductV1.Where(p => p.Type == "Acc" &&
                                   p.Category == "Mouse").ToList().Count();
                dashboard.Keyboard = _Entity.ProductV1.Where(p => p.Type == "Acc" &&
                                   p.Category == "Keyboards").ToList().Count();
                dashboard.JoyStick = _Entity.ProductV1.Where(p => p.Type == "Acc" &&
                                   p.Category == "Joysticks").ToList().Count();
                dashboard.Speaker = _Entity.ProductV1.Where(p => p.Type == "Acc" &&
                                   p.Category == "Speakers").ToList().Count();
                dashboard.Camera = _Entity.ProductV1.Where(p => p.Type == "Acc" &&
                                   p.Category == "Cameras").ToList().Count();
               

                return View(dashboard);
            }
        }
        #endregion
  
        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(User model)
        {
            if (model.UserName == "Admin" && model.Password == "Admin")
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Login");
            }
        }
        #endregion

        #region Game
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetGameList()
        {
            //if (Session["UserID"] != null)
            //{
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.Products.Where(g => g.Type == "Game").OrderByDescending(o => o.ProductId).ToList();
                GridDataSource gobj = new GridDataSource
                {
                    data = lst.ToList(),
                    length = lst.Count
                };
                return Json(gobj, JsonRequestBehavior.AllowGet);
            }

            //}
            //else
            //    return Json("[]");
        }
        [HttpPost]
        public JsonResult GetTagsdrp()
        {
            try
            {
                using (var _Entity = new GamesEntities())
                {
                    var lst = _Entity.Genres.Select(x => new
                    {
                        ID = x.GenreId,
                        Name = x.Genre1
                    }).ToList();
                    return Json(lst, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Game()
        {
            using (var _Entity = new GamesEntities())
            {
                IEnumerable<SelectListItem> items = _Entity.Genres.Select(c => new SelectListItem
                {
                    Value = c.GenreId.ToString(),
                    Text = c.Genre1

                }).ToList();
                ViewBag.Genres = items;
                return View();
            }

        }

        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            string Action = "Index";
            string DefaultView = "Product";

            if (model.Type == "Game")
            {
                Action = "Index";
                DefaultView = "Game";

            }

            if (model.Type == "Acc")
            {
                Action = "AccList";

            }
            if (model.Type == "Console")
            {
                Action = "Consoles";

            }

            try
            {
                //if (!ModelState.IsValid)
                //    return View("Game");

                using (var _Entity = new GamesEntities())
                {

                    _Entity.Entry(model).State = (model.ProductId == 0 ? EntityState.Added : EntityState.Modified);
                    _Entity.SaveChanges();
                    TempData["Result"] = "Game Sucessfully Updated.";



                    return RedirectToAction(Action);
                }

            }
            catch (Exception e)
            {
                TempData["Error"] = "Error : " + e.Message.ToString();
                return View(DefaultView);
                //return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult ProductEdit(int Id)
        {
            try
            {
                Product model = new Product();
                using (var _Entity = new GamesEntities())
                {
                    model = _Entity.Products.Where(x => x.ProductId == Id).FirstOrDefault();
                }
                //TempData["EAccountmodel"] = model;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ProductDelete(int ID)
        {
            try
            {
                using (var _Entity = new GamesEntities())
                {
                    var _Data = _Entity.Products.Where(x => x.ProductId == ID).SingleOrDefault();
                    if (_Data != null)
                    {
                        _Entity.Products.Remove(_Data);
                        _Entity.SaveChanges();
                        return Json("true", JsonRequestBehavior.AllowGet);
                    }
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Accessories
        public ActionResult AccList()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAccessoriesList()
        {
            //if (Session["UserID"] != null)
            //{
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.Products.Where(g => g.Type == "Acc")
                         .OrderByDescending(o => o.ProductId).ToList();
                GridDataSource gobj = new GridDataSource
                {
                    data = lst.ToList(),
                    length = lst.Count
                };
                return Json(gobj, JsonRequestBehavior.AllowGet);
            }

            //}
            //else
            //    return Json("[]");
        }

        #endregion

        #region Consoles
        public ActionResult Consoles()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetConsolesList()
        {
            //if (Session["UserID"] != null)
            //{
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.Products.Where(g => g.Type == "Console")
                         .OrderByDescending(o => o.ProductId).ToList();
                GridDataSource gobj = new GridDataSource
                {
                    data = lst.ToList(),
                    length = lst.Count
                };
                return Json(gobj, JsonRequestBehavior.AllowGet);
            }

            //}
            //else
            //    return Json("[]");
        }
        #endregion

        #region Game Images
        public ActionResult Images(int id)
        {
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.ProductImages.Where(g => g.ProductId == id).ToList();
                return View(lst);
            }
        }
        [HttpPost]
        public ActionResult UploadFiles(string id)
        {

            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = Guid.NewGuid().ToString() + "_" + DateTime.Today.ToShortDateString().Replace("/", "_").ToString(); ;
                        }
                        else
                        {
                            fname = Guid.NewGuid().ToString() + "_" + DateTime.Today.ToShortDateString().Replace("/", "_").ToString(); ;
                        }

                        string fileName = fname + Path.GetExtension(file.FileName);

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Images/"), fname + Path.GetExtension(file.FileName));
                        file.SaveAs(fname);

                        using (var _Entity = new GamesEntities())
                        {
                            ProductImage model = new ProductImage();
                            model.ProductId = Convert.ToInt32(id);
                            model.ImagePath = fileName;

                            _Entity.Entry(model).State = EntityState.Added;
                            _Entity.SaveChanges();
                            TempData["Result"] = "Game Sucessfully Updated.";
                        }
                    }
                    // Returns message that successfully uploaded  
                    return Json("Image Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        [HttpGet]
        public JsonResult GetGameImagesList(int Id)
        {
            //if (Session["UserID"] != null)
            //{
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.Products.Where(g => g.ProductId == Id).ToList();
                GridDataSource gobj = new GridDataSource
                {
                    data = lst.ToList(),
                    length = lst.Count
                };
                return Json(gobj, JsonRequestBehavior.AllowGet);
            }

            //}
            //else
            //    return Json("[]");
        }
        [HttpPost]
        public JsonResult ImageDelete(int ID)
        {
            try
            {
                using (var _Entity = new GamesEntities())
                {
                    var _Data = _Entity.ProductImages.Where(x => x.ImageId == ID).SingleOrDefault();
                    if (_Data != null)
                    {
                        _Entity.ProductImages.Remove(_Data);
                        _Entity.SaveChanges();
                        return Json("true", JsonRequestBehavior.AllowGet);
                    }
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Exchange
        public ActionResult ExchangeList()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetExchangeList()
        {
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.Exchanges.OrderByDescending(o => o.ExchangeId).ToList();
                GridDataSource gobj = new GridDataSource
                {
                    data = lst.ToList(),
                    length = lst.Count
                };
                return Json(gobj, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Exchange()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExchange(Exchange model)
        {
            try
            {

                using (var _Entity = new GamesEntities())
                {
                    _Entity.Entry(model).State = (model.ExchangeId == 0 ? EntityState.Added : EntityState.Modified);
                    _Entity.SaveChanges();
                    TempData["Result"] = "Game Sucessfully Updated.";
                    return RedirectToAction("ExchangeList");
                }

            }
            catch (Exception e)
            {
                TempData["Error"] = "Error : " + e.Message.ToString();
                return RedirectToAction("ExchangeList");
            }
        }
        [HttpPost]
        public JsonResult ExchangeEdit(int Id)
        {
            try
            {
                Exchange model = new Exchange();
                using (var _Entity = new GamesEntities())
                {
                    model = _Entity.Exchanges.Where(x => x.ExchangeId == Id).FirstOrDefault();
                }
                //TempData["EAccountmodel"] = model;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult ExchangeDelete(int ID)
        {
            try
            {
                using (var _Entity = new GamesEntities())
                {
                    var _Data = _Entity.Exchanges.Where(x => x.ExchangeId == ID).SingleOrDefault();
                    if (_Data != null)
                    {
                        _Entity.Exchanges.Remove(_Data);
                        _Entity.SaveChanges();
                        return Json("true", JsonRequestBehavior.AllowGet);
                    }
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Slider
        public ActionResult Slider()
        {
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.SliderVs.ToList();
                return View(lst);
            }

        }
        [HttpPost]
        public ActionResult UploadSlider(string id)
        {

            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = Guid.NewGuid().ToString() + "_" + DateTime.Today.ToShortDateString().Replace("/", "_").ToString(); ;
                        }
                        else
                        {
                            fname = Guid.NewGuid().ToString() + "_" + DateTime.Today.ToShortDateString().Replace("/", "_").ToString(); ;
                        }

                        string fileName = fname + Path.GetExtension(file.FileName);

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Images/"), fname + Path.GetExtension(file.FileName));
                        file.SaveAs(fname);

                        using (var _Entity = new GamesEntities())
                        {
                            ProductImage model = new ProductImage();
                            model.ProductId = Convert.ToInt32(id);
                            model.ImagePath = fileName;
                            model.Type = "Slider";
                            _Entity.Entry(model).State = EntityState.Added;
                            _Entity.SaveChanges();
                            TempData["Result"] = "Game Sucessfully Updated.";
                        }
                    }
                    // Returns message that successfully uploaded  
                    return Json("Image Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        [HttpPost]
        public JsonResult GetProductdrp()
        {
            try
            {
                using (var _Entity = new GamesEntities())
                {
                    var lst = _Entity.Products.Where(g => g.Type == "Game").Select(x => new
                    {
                        ID = x.ProductId,
                        Name = x.Title
                    }).ToList();
                    return Json(lst, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("[]", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Orders
        public ActionResult OrdersList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetOrderList()
        {
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.OrderVs.OrderByDescending(o => o.Date).ToList();
                GridDataSource gobj = new GridDataSource
                {
                    data = lst.ToList(),
                    length = lst.Count
                };
                return Json(gobj, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Order(int Id)
        {
            Session["OrderId"] = Id;
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.Orders.Where(o => o.OrderId == Id).FirstOrDefault();
                return View(lst);
            }

        }

        public PartialViewResult Items()
        {
            int Id = Convert.ToInt32(Session["OrderId"].ToString());
            using (var _Entity = new GamesEntities())
            {
                var lst = _Entity.OrderDetails.Where(o => o.OrderId == Id).ToList();
                return PartialView("_Items", lst);
            }
        }

        [HttpPost]
        public JsonResult OrderDelete(int ID)
        {
            try
            {
                using (var _Entity = new GamesEntities())
                {
                    var _Data = _Entity.Orders.Where(x => x.OrderId == ID).SingleOrDefault();
                    if (_Data != null)
                    {
                        _Entity.Orders.Remove(_Data);
                        _Entity.SaveChanges();
                        return Json("true", JsonRequestBehavior.AllowGet);
                    }
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}