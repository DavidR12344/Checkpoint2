using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2.models
{
    public class Product : Category
    {
        private List<Product> productList = new List<Product>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        public Product(string categoryName, string productName, int price) : base(categoryName)
        {
            ProductName = productName;
            Price = price;
            productList.Add(this);
        }

        /// <summary>
        /// Get and set method for ProductName
        /// </summary>

        public string ProductName { get; set; }

        /// <summary>
        /// Get and set method for Price
        /// </summary>

        public int Price { get; set; }


        /// <summary>
        /// Calculates total price from all products in list with Linq
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static int Sum(List<Product> products)
        {
            return products.Sum(product => product.Price);
        }

        /// <summary>
        /// Sort list price from low to high with Linq
        /// </summary>
        /// <param name="productList"></param>
        /// <returns></returns>

        public static List<Product> LowToHigh(List<Product> productList)
        {
            List<Product> sortedList = productList.OrderBy(product => product.Price).ToList();
            return sortedList;
        }
         
        /// <summary>
        /// Search a product by name with Linq
        /// </summary>
        /// <param name="productList"></param>
        /// <param name="productName"></param>
        /// <returns></returns>

        public static Product Search(List<Product> productList, string productName)
        {
            return productList.FirstOrDefault(product => product.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }

    }
}
