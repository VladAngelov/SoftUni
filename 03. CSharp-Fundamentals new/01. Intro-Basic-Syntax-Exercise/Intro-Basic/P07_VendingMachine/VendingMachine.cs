namespace P07_VendingMachine
{
    using System;

    public class VendingMachine
    {
        static void Main()
        {
            string noMoney = "Sorry, not enough money";
            string purchased = "Purchased ";
            string noProduct = "Invalid product";
            string leftMoney = "Change: ";

            decimal totalMoney = 0.0m;

            decimal nutsPrice = 2m;
            decimal waterPrice = 0.7m;
            decimal crispsPrice = 1.5m;
            decimal sodaPrice = 0.8m;
            decimal cokePrice = 1m;


           // Console.WriteLine("Input money or Start: ");

            string input = Console.ReadLine().ToLower();

            while (input != "start")
            {
                decimal coins = decimal.Parse(input);

                if (coins == 0.1m || coins == 0.2m || coins == 0.5m || coins == 1m || coins == 2m )
                {
                    totalMoney = totalMoney + coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

                input = Console.ReadLine().ToLower();
            }

          //  Console.WriteLine("Choose product or End: ");

            input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                switch (input)
                {
                    case "nuts":
                        if (totalMoney >= nutsPrice)
                        {
                            totalMoney -= nutsPrice;

                            Console.WriteLine(purchased + $"{input}");
                        }
                        else
                        {
                            Console.WriteLine(noMoney);
                        }
                        break;

                    case "water":
                        if (totalMoney >= waterPrice)
                        {
                            totalMoney -= waterPrice;

                            Console.WriteLine(purchased + $"{input}");
                        }
                        else
                        {
                            Console.WriteLine(noMoney);
                        }
                        break;

                    case "crisps":
                        if (totalMoney >= crispsPrice)
                        {
                            totalMoney -= crispsPrice;

                            Console.WriteLine(purchased + $"{input}");
                        }
                        else
                        {
                            Console.WriteLine(noMoney);
                        }
                        break;

                    case "soda":
                        if (totalMoney >= sodaPrice)
                        {
                            totalMoney -= sodaPrice;

                            Console.WriteLine(purchased + $"{input}");
                        }
                        else
                        {
                            Console.WriteLine(noMoney);
                        }
                        break;

                    case "coke":
                        if (totalMoney >= cokePrice)
                        {
                            totalMoney -= cokePrice;

                            Console.WriteLine(purchased + $"{input}");
                        }
                        else
                        {
                            Console.WriteLine(noMoney);
                        }
                        break;

                    default:
                        Console.WriteLine(noProduct);
                        break;
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine(leftMoney + $"{totalMoney:f2}");
        }
    }
}