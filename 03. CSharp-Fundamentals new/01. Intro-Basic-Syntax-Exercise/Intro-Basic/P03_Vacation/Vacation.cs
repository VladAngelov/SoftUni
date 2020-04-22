namespace P03_Vacation
{
    using System;

    public class Vacation
    {
        static void Main()
        {
            decimal studentsFriday = 8.45m;
            decimal studentsSaturday = 9.80m;
            decimal studentsSunday = 10.46m;

            decimal businessFriday = 10.90m;
            decimal businessSaturday = 15.60m;
            decimal businessSunday = 16m;

            decimal regularFriday = 15m;
            decimal regularSaturday = 20m;
            decimal regularSunday = 22.50m;

            decimal total = 0.0m;
            decimal price = 0.0m;

            decimal studentDiscount = 0.15m;
            decimal regularDiscount = 0.05m;

            string errorMessage = "Invalid input!";

            Console.Write("Input people count: ");
            int count = int.Parse(Console.ReadLine());

            Console.Write("Input group: ");
            string group = Console.ReadLine().ToLower();

            Console.Write("Input day: ");
            string day = Console.ReadLine().ToLower();

            if (group == "students")
            {
                if (day == "friday")
                {
                    price = studentsFriday * count;

                    if (count >= 30)
                    {
                        total = price - (price * studentDiscount);
                    }
                    else
                    {
                        total = price;
                    }
                }

                if (day == "saturday")
                {
                    price = studentsSaturday * count;

                    if (count >= 30)
                    {
                        total = price - (price * studentDiscount);
                    }
                    else
                    {
                        total = price;
                    }
                }

                if (day == "sunday")
                {
                    price = studentsSunday * count;

                    if (count >= 30)
                    {
                        total = price - (price * studentDiscount);
                    }
                    else
                    {
                        total = price;
                    }
                }
            }

            else if (group == "business")
            {
                if (day == "friday")
                {
                    price = businessFriday * count;

                    if (count >= 100)
                    {
                        total = businessFriday * (count - 10);
                    }
                    else
                    {
                        total = price;
                    }
                }

                if (day == "saturday")
                {
                    price = businessSaturday * count;

                    if (count >= 100)
                    {
                        total = businessSaturday * (count - 10);
                    }
                    else
                    {
                        total = price;
                    }
                }

                if (day == "sunday")
                {
                    price = businessSunday * count;

                    if (count >= 100)
                    {
                        total = businessSunday * (count - 10);
                    }
                    else
                    {
                        total = price;
                    }
                }
            }

            else if (group == "regular")
            {
                if (day == "friday")
                {
                    price = regularFriday * count;

                    if (count >= 10 && count <= 20)
                    {
                        total = price - (price * regularDiscount);
                    }
                    else
                    {
                        total = price;
                    }
                }

                if (day == "saturday")
                {
                    price = regularSaturday * count;

                    if (count >= 10 && count <= 20)
                    {
                        total = price - (price * regularDiscount);
                    }
                    else
                    {
                        total = price;
                    }
                }

                if (day == "sunday")
                {
                    price = regularSunday * count;

                    if (count >= 10 && count <= 20)
                    {
                        total = price - (price * regularDiscount);
                    }
                    else
                    {
                        total = price;
                    }
                }
            }
            else
            {
                Console.WriteLine(errorMessage);
            }

            string message = $"Total price: {total:f2}";

            Console.WriteLine(message);
        }
    }
}