﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    internal class Product
    {
        //properties
        private string Name { get; set; }
        private string Category { get; set; }
        private string Description { get; set; }
        private double Price { get; set; }
        public static int productCount;
        //constructor
        public Product(string _name, string _category, string _description, double _price)
        {
            Name = _name;
            Category = _category;
            Description = _description;
            Price = _price;
        }
        //methods
        public static void Inventory(List<Product> productList)
        {
            foreach (Product p in productList)
            {
                Console.WriteLine(String.Format("{0, -4}{1,116}",$"{productList.IndexOf(p) + 1}.", p.ToString()));
            }
        }

        //Method adjust inventory after a sale
        public static void RemoveFromInventory(int index, List<Product> productList)
        {
            productList.RemoveAt(index - 1);
        }

        //Method to handle returns
        public static void Returns(Product returned, List<Product> productList)
        {
            productList.Add(returned);
        }

        public override string ToString()
        {
            return String.Format("{0, -20}{1, -10}{2, -78}{3, -8}",$"{Name}", $"{Category}", $"{Description}", $"{Price}");
        }

    }
}
