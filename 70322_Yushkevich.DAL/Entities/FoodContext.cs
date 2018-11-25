using _70322_Yushkevich.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace _70322_Yushkevich.DAL
{
    public partial class ApplicationDbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        private void Populate()
        {
            if (!Dishes.Any())
            {
                List<Dish> dishes = new List<Dish>
                {
                    new Dish {DishId=1, DishName="Суп-харчо", Description="Очень острый, невкусный",Calories =200, GroupName="Супы" },
                    new Dish {DishId=2, DishName="Борщ", Description="Много сала, без сметаны", Calories =330, GroupName="Супы" },
                    new Dish {DishId=3, DishName="Котлета пожарская", Description ="Хлеб - 80%, Морковь - 20%", Calories =635, GroupName="Вторые блюда" },
                    new Dish {DishId=4, DishName="Макароны по-флотски", Description="С охотничьей колбаской", Calories =524, GroupName="Вторые блюда" },
                    new Dish {DishId=5, DishName="Компот", Description="Быстро растворимый, 2 литра", Calories =180, GroupName="Напитки" },
                    new Dish {DishId=5, DishName="Entities", Description="FoodContext", Calories =0, GroupName="DAL" }
                };

                Dishes.AddRange(dishes);
                SaveChanges();
            }
        }
    }
}

