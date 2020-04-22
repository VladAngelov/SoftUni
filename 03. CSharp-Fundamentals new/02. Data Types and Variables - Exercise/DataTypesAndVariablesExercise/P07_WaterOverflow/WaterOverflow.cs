namespace P07_WaterOverflow
{
    using System;

    public class WaterOverflow
    {
        static void Main()
        {
            int waterTankCapacity = 255;

            string capacityError = "Insufficient capacity!";

            int inputLines = int.Parse(Console.ReadLine());

            int usedLitres = 0;

            for (int i = 0; i < inputLines; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (liters > waterTankCapacity)
                {
                    Console.WriteLine(capacityError);
                }
                else
                {
                    waterTankCapacity -= liters;

                    usedLitres += liters;
                }
            }

            Console.WriteLine(usedLitres);
        }
    }
}