using _70322_Yushkevich.DAL.Entities;
using _70322_Yushkevich.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace _70322_Yushkevich.DAL //.Repositories
{
    public class EFDishRepository : IRepository<Dish>
    {
        private ApplicationDbContext context;
        private DbSet<Dish> table;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public EFDishRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.Dishes;
        }
        public void Create(Dish t)
        {
            table.Add(t);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var item = context.Dishes.Find(id);
            if (item != null)
                context.Dishes.Remove(item);
            context.SaveChanges();
        }
        public IEnumerable<Dish> Find(Func<Dish, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }
        public Dish Get(int id)
        {
            return table.Find(id);
        }
        public IEnumerable<Dish> GetAll()
        {
            return table;
        }
        public Task<Dish> GetAsync(int id)
        {
            //return table.FindAsync(id);
            return context.Dishes.FindAsync(id);
        }
        public void Update(Dish t)
        {
            // если изображение не загружено,
            // то использовать изображение из базы данных
            if (t.Image == null)
            {
                var dish = context.Dishes
                .AsNoTracking()
                .Where(d => d.DishId == t.DishId)
                .FirstOrDefault();
                t.Image = dish.Image;
                t.MimeType = dish.MimeType;
            }
            context.Entry<Dish>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

