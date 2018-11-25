using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70322_Yushkevich.DAL.Entities
{
    public class Dish
    {
        public int DishId { get; set; }           // id блюда
        public string DishName { get; set; }      // название блюда
        public string Description { get; set; }   // описание блюда
        public int Calories { get; set; }         // кол. калорий на порцию
        public string GroupName { get; set; }     // группа блюд (например, первые блюда, напистки и т.д.)
        public byte[] Image { get; set; }         // данные изображения
        public string MimeType { get; set; }      // Mime - тип данных изображения
    }
}
