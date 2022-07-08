using System;
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
                Console.WriteLine($"{productList.IndexOf(p) + 1}." + p.ToString());
            }
        }



    }
}
