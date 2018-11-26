using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _70322_Yushkevich.DAL;
using _70322_Yushkevich.DAL.Entities;
using _70322_Yushkevich.DAL.Interfaces;


namespace _70322_Yushkevich.Controllers
{
    public class AdminController : Controller
    {

        IRepository<Dish> repository;  //репозиторий

        public AdminController(IRepository<Dish> repo)  //конструктор
        {
            repository = repo;
        }

        // GET: Admin
        public ActionResult Index() //метод индекс
        {
            return View(repository.GetAll());
        }

        
        // GET: Admin/Create -----------------------------------------
        public ActionResult Create()
        {
            return View(new Dish());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Dish dish, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    dish.Image = new byte[count];
                    imageUpload.InputStream.Read(dish.Image, 0, (int)count);
                    dish.MimeType = imageUpload.ContentType;
                }
                try
                {
                    // TODO: Add insert logic here
                    repository.Create(dish);

                    TempData["Message"] = string.Format("Объект \"{0}\" был добавлен.",
                    dish.DishName);

                    return RedirectToAction("Index");
                }
                catch
                {
                    //return View(dish); ???
                    return View();
                }
            }
            else return View(dish);
        }

        // GET: Admin/Edit/5 ------------------------------------------
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Dish dish, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    dish.Image = new byte[count];
                    imageUpload.InputStream.Read(dish.Image, 0, (int)count);
                    dish.MimeType = imageUpload.ContentType;
                }
                try
                {
                    // TODO: Add update logic here
                    repository.Update(dish);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(dish);
                }
            }
            return View(dish);
        }

        // GET: Admin/Delete/5 -----------------------------------------
        public ActionResult Delete(int id)
        {
            Dish dish = repository.Get(id);

            if (dish == null)
            {
                return HttpNotFound();
            }

            return View(dish);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Dish dish = repository.Get(id);

                if (dish == null)
                {
                    return HttpNotFound();
                }

                repository.Delete(id);

                TempData["Message"] = string.Format("Объект \"{0}\" был удален.",
                     dish.DishName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
