namespace P01_CountCharsInAString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CountCharsInAString
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int lenght = input.Length;

            Dictionary<char, int> countChars = new Dictionary<char, int>();

            foreach (var item in input)
            {
                var arr = item.ToCharArray();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (!countChars.ContainsKey(arr[i]))
                    {
                        countChars.Add(arr[i], 1);
                    }
                    else
                    {
                        countChars[arr[i]]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in countChars)
            {
                char symbol = item.Key;

                int count = item.Value;

                sb.AppendLine($"{symbol} -> {count}");
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}