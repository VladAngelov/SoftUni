namespace P03_HouseParty
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HouseParty
    {
        static void Main()
        {
            List<string> guests = new List<string>();

            int count = int.Parse(Console.ReadLine());

            while (count > 0)
            {
                string name = String.Empty;

                string command = String.Empty;

                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int inputLength = input.Length;

                if (inputLength == 3)
                {
                    name = input[0];

                    command = input[1] + " " + input[2]; 
                }

                if (inputLength == 4)
                {
                    name = input[0];

                    command = input[1] + " " + input[2] + " " + input[3];
                }

                switch (command)
                {
                    case "is going!":
                        if (guests.Contains(name))
                        {
                            Console.WriteLine($"{name} is already in the list!");
                            break;
                        }
                        guests.Add(name);
                        break;

                    case "is not going!":
                        if (!guests.Contains(name))
                        {
                            Console.WriteLine($"{name} is not in the list!");
                            break;
                        }
                        guests.Remove(name);
                        break;
                }

                count--;
            }

            StringBuilder sb = new StringBuilder();

            foreach (string names in guests)
            {
                sb.AppendLine(names);
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}