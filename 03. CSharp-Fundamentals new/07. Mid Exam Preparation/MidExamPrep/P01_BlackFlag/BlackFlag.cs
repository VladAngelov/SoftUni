namespace P01_BlackFlag
{
    using System;

    class BlackFlag
    {
        static void Main()
        {
            double totalPlunder = 0.0;

            double percentage = 0.0;

            int days = int.Parse(Console.ReadLine());

            if (days <= 0 || days > 100000)
            {
                Console.Write("Invalid days! Try again: ");

                days = int.Parse(Console.ReadLine());
            }

            int dailyPlunder = int.Parse(Console.ReadLine());

            if (dailyPlunder <= 0 || dailyPlunder > 50)
            {
                Console.Write("Invalid daily plunder! Try again: ");

                dailyPlunder = int.Parse(Console.ReadLine());
            }

            double expectedPlunder = double.Parse(Console.ReadLine());

            if (expectedPlunder <= 0 || expectedPlunder > 10000)
            {
                Console.Write("Invalid expected plunder! Try again: ");

                expectedPlunder = double.Parse(Console.ReadLine());
            }

            for (int i = 1; i <= days; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.3;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                percentage = totalPlunder / expectedPlunder * 100;

                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}