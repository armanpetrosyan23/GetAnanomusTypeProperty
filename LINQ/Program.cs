using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections;

namespace LINQ
{
    class Program
    {

        static IList GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            // Map set of anonymous objects to an Array object.

            //List<Anonymous type>
            return nameDesc.ToList();
        }

        static void Main(string[] args)
        {

            // This array will be the basis of our testing...
            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH",NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love",NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible",NumberInStock = 120},
                new ProductInfo{ Name = "Crunchy Pops", Description = "Cheezy, peppery goodness",NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet",NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone lovespizza!", NumberInStock = 73}
            };


            var collection = GetProjectedSubset(itemsInStock);
            int index = 0;
            //Get anonymous object property and value
            foreach (var item in collection)
            {
                PropertyInfo[] properties = item.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(property.Name + " " + property.GetValue(item));
                }
                Console.WriteLine($"Object N_{index++}");
            }
            Console.ReadLine();
        }

    }
}
