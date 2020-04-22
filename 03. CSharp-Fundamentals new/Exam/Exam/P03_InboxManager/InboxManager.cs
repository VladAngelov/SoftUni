namespace P03_InboxManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InboxManager
    {
        static void Main()
        {
            string[] commands = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> usersAndEmails = new Dictionary<string, List<string>>();

            while (commands[0] != "Statistics")
            {
                string command = commands[0];
                string username = commands[1];

                switch (command)
                {
                    case "Add":
                        if (!usersAndEmails.ContainsKey(username))
                        {
                            List<string> emails = new List<string>();
                            usersAndEmails.Add(username, emails);
                        }
                        else
                        {
                            Console.WriteLine($"{username} is already registered");
                        }
                        break;

                    case "Send":
                        string email = commands[2];
                        usersAndEmails[username].Add(email); 
                        break;

                    case "Delete":
                        if (!usersAndEmails.ContainsKey(username))
                        {
                            Console.WriteLine($"{username} not found!");
                        }
                        else
                        {
                            usersAndEmails.Remove(username);
                        }
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries);
            }
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Users count: {usersAndEmails.Count}");

            foreach (var item in usersAndEmails
                .OrderByDescending(u => u.Value.Count)
                .ThenBy(u => u.Key))
            {
                string name = item.Key;

                sb.AppendLine(name);

                foreach (var mail in item.Value)
                {
                    sb.AppendLine($" - {mail}");
                }
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}