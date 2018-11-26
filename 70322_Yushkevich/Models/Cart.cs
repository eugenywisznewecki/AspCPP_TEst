using _70322_Yushkevich.DAL.Entities;
using _70322_Yushkevich.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _70322_Yushkevich.Models
{
    //[ModelBinder(typeof(CartModelBinder))]
    public class Cart
    {


        Dictionary<int, CartItem> cartItems;
        public Cart()
        {
            cartItems = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="dish">объект для добавления</param>
        public void AddItem(Dish dish)
        {
            if (cartItems.ContainsKey(dish.DishId))
                cartItems[dish.DishId].Quantity += 1;
            else
                cartItems.Add(dish.DishId,
                new CartItem { Dish = dish, Quantity = 1 });
        }
        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="dish">Объект для удаления</param>
        public void RemoveItem(Dish dish)
        {
            if (cartItems[dish.DishId].Quantity == 1)
                cartItems.Remove(dish.DishId);
            else
                cartItems[dish.DishId].Quantity -= 1;
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
        }
        /// <summary>
        /// Получение суммы калорий
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            return cartItems
            .Values
            .Sum(i => i.Dish.Calories * i.Quantity);
        }
        /// <summary>
        /// Получение содержимого корзины
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartItem> GetItems()
        {
            return cartItems.Values;
        }



    }
}