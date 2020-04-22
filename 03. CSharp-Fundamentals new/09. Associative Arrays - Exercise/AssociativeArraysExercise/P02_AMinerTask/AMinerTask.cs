namespace P02_AMinerTask
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AMinerTask
    {
        static void Main()
        {
            string resource = Console.ReadLine();
           
            Dictionary<string, int> resourceAndQuantity = new Dictionary<string, int>();

            while (resource != "stop")
            {
               int quantity = int.Parse(Console.ReadLine());

                if (!resourceAndQuantity.ContainsKey(resource))
                {
                    resourceAndQuantity.Add(resource, quantity);
                }
                else
                {
                    resourceAndQuantity[resource] += quantity;
                }

                resource = Console.ReadLine();
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in resourceAndQuantity)
            {
                string res = item.Key;

                int count = item.Value;

                sb.AppendLine($"{res} -> {count}");
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}