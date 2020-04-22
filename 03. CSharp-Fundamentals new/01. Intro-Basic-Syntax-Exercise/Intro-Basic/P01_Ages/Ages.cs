namespace P01_Ages
{
    using System;

    public class Ages
    {
        static void Main()
        {
            string baby = "baby";
            string child = "child";
            string teenager = "teenager";
            string adult = "adult";
            string elder = "elder";
            string error = "The value must be positive.";

            int ages = int.Parse(Console.ReadLine());

            if (ages >= 0 && ages <= 2)
            {
                Console.WriteLine(baby);
            }
            else if (ages >= 3 && ages <= 13)
            {
                Console.WriteLine(child);
            }
            else if (ages >= 14 && ages <= 19)
            {
                Console.WriteLine(teenager);
            }
            else if (ages >= 20 && ages <= 65)
            {
                Console.WriteLine(adult);
            }
            else if (ages >= 66)
            {
                Console.WriteLine(elder);
            }
            else
            {
                Console.WriteLine(error);
                return;
            }
        }
    }
}