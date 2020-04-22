namespace P04_Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Orders
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Product> products = new List<Product>();

            while (input[0] != "buy")
            {
                string name = input[0];
                decimal price = decimal.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                Product product = new Product(name, quantity, price);

                if (!products.Contains(products.Where(p => p.Name == name).FirstOrDefault()))
                {
                    products.Add(product);
                }
                else
                {
                    var productFromList = products
                        .Where(p => p.Name == name)
                        .FirstOrDefault();

                    productFromList.Price = price;
                 
                    productFromList.Quantity += quantity;
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (Product pr in products)
            {
                Console.WriteLine(pr.ToString());
            }
        }
    }

    public class Product
    {
        public Product(string name, int quantity, decimal price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Fee => this.Quantity * this.Price;

        public override string ToString()
        {
            string result = $"{this.Name} -> {this.Fee:f2}";

            return result;
        }
    }
}