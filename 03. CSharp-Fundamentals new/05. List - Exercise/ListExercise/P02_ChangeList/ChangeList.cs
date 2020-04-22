namespace P02_ChangeList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChangeList
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                int inputLenght = input.Length;

                string command = String.Empty;

                StringBuilder sb = new StringBuilder();

                int indexOfNumber = 0;

                int numberForIndex = 0;

                if (inputLenght > 2)
                {
                    indexOfNumber = int.Parse(input[2]);
                    numberForIndex = int.Parse(input[1]);
                }

                switch (input[0].ToLower())
                {
                    case "insert":
                        numbers.Insert(indexOfNumber, numberForIndex);
                        break;

                    case "delete":
                        int numberToRemove = int.Parse(input[1]);
                        int count = numbers.Where(n => n == numberToRemove).Count();

                        for (int i = 0; i < count; i++)
                        {
                            numbers.Remove(numberToRemove);
                        }
                        break;

                    case "end":
                        foreach (var item in numbers)
                        {
                            sb.Append(item + " ");
                        }
                        Console.WriteLine(sb.ToString().TrimEnd());
                        return;

                    default:
                        continue;
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}