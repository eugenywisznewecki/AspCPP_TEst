using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _70322_Yushkevich.DAL.Entities;
using _70322_Yushkevich.DAL.Interfaces;
using _70322_Yushkevich.Models;
//using 70322_Yushkevich.Models;




namespace _70322_Yushkevich.Controllers
{
    public class DishController : Controller
    {
        int pageSize = 3;

        // Инициализация списка объектов:
        //List<Dish> dishes = new List<Dish>
        //{
        //new Dish {DishId=1, DishName="Суп-харчо", Description="Очень острый, невкусный",Calories =200, GroupName="Супы" },
        //new Dish {DishId=2, DishName="Борщ", Description="Много сала, без сметаны", Calories =330, GroupName="Супы" },
        //new Dish {DishId=3, DishName="Котлета пожарская", Description="Хлеб - 80%, Морковь - 20%", Calories =635, GroupName="Вторые блюда" },
        //new Dish {DishId=4, DishName="Макароны по-флотски", Description="С охотничьей колбаской", Calories =524, GroupName="Вторые блюда" },
        //new Dish {DishId=5, DishName="Компот", Description="Быстро растворимый, 2 литра", Calories =180, GroupName="Напитки" }
        //};

        IRepository<Dish> repository;
        public DishController(IRepository<Dish> repo)
        {
            repository = repo;
        }

        // GET: Dish
        public ActionResult List(int page=1)
        {
            var lst = repository.GetAll().OrderBy(d => d.Calories);
            return View(PageListViewModel<Dish>.CreatePage(lst, page, pageSize));

            //return View(dishes);
            //return View(repository.GetAll());
        }
    }
}