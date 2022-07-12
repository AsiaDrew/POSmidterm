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
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
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
        public override string ToString()
        {
            return String.Format("{0, -20}{1, -10}{2, -78}{3, -8}",$"{Name}", $"{Category}", $"{Description}", $"${Price}");
        }

    }
}
