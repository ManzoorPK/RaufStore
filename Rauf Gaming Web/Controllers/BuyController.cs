using Rauf_Gaming.Classes;
using Rauf_Gaming.Models;
using Rauf_Gaming_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rauf_Gaming_Web.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        public ActionResult CheckOut()
        {
            if (Session["MyCart"] != null)
            {
                List<CartProduct> list = Session["MyCart"] as List<CartProduct>;
                if (list.Count == 0)
                {
                    Session["Total"] = null;
                    return RedirectToAction("Shop", "Game");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Shop", "Game");
            }

        }
        public ActionResult MyCart()
        {
            if (Session["MyCart"] != null)
            {
                List<CartProduct> list = Session["MyCart"] as List<CartProduct>;
                if (list.Count == 0)
                {
                    Session["Total"] = null;
                    return RedirectToAction("Shop", "Game");
                }

                return View(list);
            }
            else
            {
                return RedirectToAction("Shop", "Game");
            }

        }

        [HttpPost]
        public JsonResult GetProduct(int Id)
        {
            ProductV1 product = new ProductV1();
            product = new Games().GetProductList().Where(g => g.ProductId == Id).FirstOrDefault();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCartItem(string Id, string type, double Qty)
        {
            List<CartProduct> cart = Session["MyCart"] as List<CartProduct>;
            var obj = cart.FirstOrDefault(x => x.Id == Id && x.Type == type);
            if (obj != null)
            {
                obj.Quantity = Qty;
                obj.Total = obj.Price * Qty;
            }
            Session["MyCart"] = cart;
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddItemToCart(CartProduct product)
        {
            List<CartProduct> cart;
            int _Total = 0;
            try
            {
                if (Session["MyCart"] != null)
                {
                    cart = Session["MyCart"] as List<CartProduct>;
                    var FindProduct = cart.Where(p => p.Id == product.Id && p.Type == product.Type).FirstOrDefault();
                    if (FindProduct != null)
                    {
                        double Qty = FindProduct.Quantity;
                        cart.Remove(FindProduct);
                        cart.Add(new CartProduct
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Photo = product.Photo,
                            Price = product.Price,
                            Quantity = product.Quantity + Qty,
                            Total = (product.Quantity + Qty) * product.Price,
                            Type = product.Type
                        });


                    }
                    else
                    {
                        cart.Add(new CartProduct
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Photo = product.Photo,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            Total = product.Quantity * product.Price,
                            Type = product.Type
                        });
                    }
                }
                else
                {
                    cart = new List<CartProduct>();
                    cart.Add(new CartProduct
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Photo = product.Photo,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        Total = product.Quantity * product.Price,
                        Type = product.Type
                    });

                    Session["MyCart"] = cart;
                }
                if (cart != null)
                {
                    _Total = cart.Count;
                    Session["NoOfCartItems"] = _Total.ToString();
                }
                return Json(_Total.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult RemoveProduct(int Id)
        {
            List<CartProduct> cart = Session["MyCart"] as List<CartProduct>;
            var product = cart.Where(c => c.Id == Id.ToString()).FirstOrDefault();
            cart.Remove(product);
            Session["MyCart"] = cart;
            Session["NoOfCartItems"] = cart.Count.ToString();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DoCheckOut(Order model)
        {
            try
            {
                if (Session["MyCart"] != null)
                {
                    using (var _Entity = new GamesEntities())
                    {
                        model.Date = DateTime.Now;
                        model.Status = "Pending";
                        _Entity.Entry(model).State = EntityState.Added;
                        _Entity.SaveChanges();

                        List<CartProduct> cart = Session["MyCart"] as List<CartProduct>;
                        foreach (var item in cart)
                        {
                            OrderDetail detail = new OrderDetail();
                            detail.OrderId = model.OrderId;
                            detail.Product = item.Name;
                            detail.Type = item.Type;
                            detail.Quantity = Convert.ToInt32(item.Quantity);
                            detail.UnitPrice = Convert.ToDecimal(item.Price);
                            detail.TotalPrice = Convert.ToInt32(item.Total);
                            _Entity.Entry(detail).State = EntityState.Added;
                            _Entity.SaveChanges();
                        }
                    }
                }

                Session["op"] = "true";
            }
            catch (Exception ex)
            {
                Session["op"] = "false";
            }
            return Redirect("Thanks");
        }
        public ActionResult Thanks()
        {
            return View();
        }
    }
}