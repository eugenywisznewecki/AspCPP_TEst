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
            context
            .Entry(new Dish { DishId = id })
            .State = EntityState.Deleted;
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
            return table.FindAsync(id);
        }
        public void Update(Dish t)
        {
            context.Entry<Dish>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

