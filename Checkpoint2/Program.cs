using Checkpoint2.models;
using System;
using System.Collections.Generic;

namespace Checkpoint2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new product - follow the steps. To present the list - enter 'P'. To quit - enter 'Q'");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "q")
                    break;

                Console.ForegroundColor = ConsoleColor.White;
                string categoryName;
                while (true)
                {
                    Console.WriteLine("Enter a Category: ");
                    categoryName = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(categoryName))
                    {
                        Console.WriteLine("Category name cannot be empty. Please enter a valid category name.");
                    }
                    else
                    {
                        break;
                    }
                }
                string productName;
                while (true)
                {
                    Console.WriteLine("Enter a Product Name: ");
                    productName = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(productName))
                    {
                        Console.WriteLine("Product name cannot be empty. Please enter a valid product name.");
                    }
                    else
                    {
                        break;
                    }
                }

                int price;
                while (true)
                {
                    Console.WriteLine("Enter a Price: ");
                    if (!int.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Invalid price. Please enter a valid integer value.");
                    }
                    else
                    {
                        break;
                    }
                }

                Product product = new Product(categoryName, productName, price);
                products.Add(product);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was successfully added!");

                if (input == "p")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("| Category            | Product Name         | Price   |");
                    Console.WriteLine("----------------------------------------------------------");
                    // Sort products by price from low to high before displaying the list
                    products = Product.LowToHigh(products);
                    foreach (var prod in products)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"| {prod.CategoryName,-20} | {prod.ProductName,-20} | {prod.Price,-5} |");
                    }
                    Console.WriteLine("----------------------------------------------------------");
                    // Calculate and display the total sum of prices
                    int totalSum = Product.Sum(products);
                    Console.WriteLine($"Total sum of prices: {totalSum}");

                    // Search for a product by name
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter the name of the product to search:");
                    string searchProductName = Console.ReadLine().Trim();
                    Product foundProduct = Product.Search(products, searchProductName);
                    if (foundProduct != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Product found: Category: {foundProduct.CategoryName}, Product Name: {foundProduct.ProductName}, Price: {foundProduct.Price}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Product not found.");
                    }
                }
            }

            // Sort products by price from low to high before displaying the list if there are products in the list
            if (products.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("| Category            | Product Name         | Price   |");
                Console.WriteLine("----------------------------------------------------------");
                products = Product.LowToHigh(products);
                foreach (var prod in products)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"| {prod.CategoryName,-20} | {prod.ProductName,-20} | {prod.Price,-5} |");
                }
                Console.WriteLine("----------------------------------------------------------");
                // Calculate and display the total sum of prices
                int totalSum = Product.Sum(products);
                Console.WriteLine($"Total sum of prices: {totalSum}");

                // Search for a product by name
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the name of the product to search:");
                string searchProductName = Console.ReadLine().Trim();
                Product foundProduct = Product.Search(products, searchProductName);
                if (foundProduct != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Product found: Category: {foundProduct.CategoryName}, Product Name: {foundProduct.ProductName}, Price: {foundProduct.Price}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("No products in the list.");
            }
        }
    }
}
