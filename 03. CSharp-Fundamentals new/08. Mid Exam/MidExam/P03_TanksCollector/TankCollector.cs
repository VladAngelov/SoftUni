namespace P03_TanksCollector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TankCollector
    {
        static void Main()
        {
            string successfullyBoughtMessage = "Tank successfully bought";
            string ownedTankMessage = "Tank is already bought";

            string soldTankMessage = "Tank successfully sold";
            string noTankMessage = "Tank not found";

            string outOfRandeIndexMessage = "Index out of range";

            List<string> premiumTanksList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int count = int.Parse(Console.ReadLine());

            while (count > 0)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                string tankName = input[1];

                switch (command)
                {
                    case "Add":
                        if (premiumTanksList.Contains(tankName))
                        {
                            Console.WriteLine(ownedTankMessage);
                        }
                        else
                        {
                            premiumTanksList.Add(tankName);

                            Console.WriteLine(successfullyBoughtMessage);
                        }
                        break;

                    case "Remove":
                        if (premiumTanksList.Contains(tankName))
                        {
                            premiumTanksList.Remove(tankName);

                            Console.WriteLine(soldTankMessage);
                        }
                        else
                        {
                            Console.WriteLine(noTankMessage);
                        }
                        break;

                    case "Remove At":
                        int index = int.Parse(tankName);

                        if (index >= 0 && index <= premiumTanksList.Count())
                        {
                            premiumTanksList.RemoveAt(index);

                            Console.WriteLine(soldTankMessage);
                        }
                        else
                        {
                            Console.WriteLine(outOfRandeIndexMessage);
                        }
                        break;

                    case "Insert":
                        int indexInsert = int.Parse(input[1]);

                        if (indexInsert >= 0 && indexInsert <= premiumTanksList.Count())
                        {
                            if (premiumTanksList.Contains(input[2]))
                            {
                                Console.WriteLine(ownedTankMessage);
                            }
                            else
                            {
                                premiumTanksList.Insert(indexInsert, input[2]);

                                Console.WriteLine(successfullyBoughtMessage);
                            }
                        }
                        else
                        {
                            Console.WriteLine(outOfRandeIndexMessage);
                        }

                        break;

                    default:
                        break;
                }

                count--;
            }

            var result = String.Join(", ", premiumTanksList);

            Console.WriteLine(result);
        }
    }
}