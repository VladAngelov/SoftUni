namespace P05_SoftUniParking
{
    using System;
    using System.Collections.Generic;

    public class SoftUniParking
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, string> users = new Dictionary<string, string>();

            while (count > 0)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                string userName = input[1];

                string licensePlateNumber = String.Empty;

                if (input.Length == 3)
                {
                    licensePlateNumber = input[2];
                }

                switch (command)
                {
                    case "register":
                        if (!users.ContainsKey(userName))
                        {
                            users.Add(userName, licensePlateNumber);

                            Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                        }
                        break;
                    
                    case "unregister":
                        if (!users.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        else
                        {
                            users.Remove(userName);

                            Console.WriteLine($"{userName} unregistered successfully");
                        }
                        break;
                    
                    default:
                        break;
                }
                
                count--;
            }
            
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}