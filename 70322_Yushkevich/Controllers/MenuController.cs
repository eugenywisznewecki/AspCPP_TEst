//<!--Lab3-->
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _70322_Yushkevich.DAL.Interfaces;

using _70322_Yushkevich.DAL.Entities;
using _70322_Yushkevich.Models;


namespace _70322_Yushkevich.Controllers
{
    public class MenuController : Controller
    {
        private List<MenuItem> items;
        private IRepository<Dish> repository;

        
        public MenuController(IRepository<Dish> rep)            
        {
            repository = rep;

            items = new List<MenuItem>
            {
            new MenuItem{Name="Домой", Controller="Home", Action="Index", Active=string.Empty},
            new MenuItem{Name="Меню", Controller="Dish", Action="List", Active=string.Empty},
            new MenuItem{Name="Администрирование", Controller="Admin", Action="Index", Active=string.Empty},
            };
        }
        
        //public string Main()
        //{
        //    return "<span> Главное меню </span>";
        //}
        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            var item = items.Where(m => m.Controller == c).FirstOrDefault();
            if(item!=null)
                item.Active = "active";
            return PartialView(items);
        }

        //public string UserInfo()
        //{
        //    return "<span> Меню пользователя </span>";
        //}
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        public PartialViewResult Side()
        {
            var groups = repository
                 .GetAll()
                 .Select(dp => dp.GroupName)
                 .Distinct();
            return PartialView(groups);

            //return "<span> Боковая панель </span>";
        }

        //public string Map()
        //{
        //    return "<span> Карта сайта </span>";
        //}
        public PartialViewResult Map()
        {
            return PartialView(items);
        }



        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
    }
}