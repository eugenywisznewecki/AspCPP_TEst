using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _70322_Yushkevich.Models;
using _70322_Yushkevich.DAL.Interfaces;
using _70322_Yushkevich.DAL.Entities;


namespace _70322_Yushkevich.Controllers
{
    public class CartController : Controller
    {

        IRepository<Dish> repository;
      

        public CartController(IRepository<Dish> repo )
        {
            repository = repo;
            //this.cart = cart;
        }

        // GET: Cart
        [Authorize]
        public ActionResult Index(Cart cart, string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(cart);//return View(GetCart());
        }


        //public Cart GetCart()
        //{
           
        //    Cart cart = Session["Cart"] as Cart;
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}


        public RedirectResult AddToCart(Cart cart, int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
            {
                cart.AddItem(item);//GetCart().AddItem(item);
                //session["Cart"] = cart;
            }
            return Redirect(returnUrl);
            }


        public PartialViewResult CartSummary(Cart cart, string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(cart);//return PartialView(GetCart());
        }


        public RedirectToRouteResult DeleteFromCart(Cart cart, int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
                cart.RemoveItem(item);//GetCart().RemoveItem(item);

            return RedirectToAction("Index", new { returnUrl });
        }


        public RedirectToRouteResult ClearCart(Cart cart, string returnUrl)
        {
            //var item = repository.Get(id);
            //if (item != null)
                cart.Clear();//GetCart().RemoveItem(item);

            return RedirectToAction("Index", new { returnUrl });
        }


    } 
}