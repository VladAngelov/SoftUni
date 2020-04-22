namespace P02_FriendlistMaintenance
{
    using System;
    using System.Text;

    public class FriendlistMaintenance
    {
        static void Main()
        {
            string[] friends = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string[] commands = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            int blacklisted = 0;

            int lost = 0;

            while (commands[0] != "Report")
            {
                switch (commands[0])
                {
                    case "Blacklist":
                        int c = 0;

                        for (int i = 0; i < friends.Length; i++)
                        {
                            if (friends[i] == commands[1])
                            {
                                Console.WriteLine($"{friends[i]} was blacklisted.");

                                friends[i] = "Blacklisted";

                                blacklisted++;

                                break;
                            }

                            if (friends[i] != commands[1])
                            {
                                c++;
                            }

                            if (c == friends.Length)
                            {
                                Console.WriteLine($"{commands[1]} was not found.");
                            }
                        }
                        break;

                    case "Error":
                        for (int i = 0; i < friends.Length; i++)
                        {
                            if (i == int.Parse(commands[1]) &&
                                friends[i] != "Lost" &&
                                friends[i] != "Blacklisted")
                            {
                                Console.WriteLine($"{friends[i]} was lost due to an error.");

                                friends[i] = "Lost";

                                lost++;

                                break;
                            }
                        }
                        break;

                    case "Change":
                        for (int i = 0; i < friends.Length; i++)
                        {
                            if (i == int.Parse(commands[1]))
                            {
                                Console.WriteLine($"{friends[i]} changed his username to {commands[2]}.");

                                friends[i] = commands[2];
                            }
                        }
                        break;

                    default:
                        break;
                }

                commands = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            sb.AppendLine("Blacklisted names: " + blacklisted);

            sb.AppendLine("Lost names: " + lost);

            foreach (string friend in friends)
            {
                sb.Append(friend + " ");
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}