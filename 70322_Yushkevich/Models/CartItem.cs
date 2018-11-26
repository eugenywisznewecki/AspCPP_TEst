using _70322_Yushkevich.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _70322_Yushkevich.Models
{
    public class CartItem
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}