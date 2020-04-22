namespace P03_MessagesManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MessagesManager
    {
        static void Main()
        {
            Dictionary<string, int> sentMessages = new Dictionary<string, int>();

            Dictionary<string, int> receivedMessages = new Dictionary<string, int>();

            int capacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split("=", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Statistics")
            {
                string command = input[0];

                switch (command)
                {
                    case "Add":
                        if (!sentMessages.ContainsKey(input[1]))
                        {
                            string name = input[1];

                            int sentMessagesCount = int.Parse(input[2]);

                            int receivedMessagesCount = int.Parse(input[3]);

                            sentMessages.Add(name, sentMessagesCount);

                            receivedMessages.Add(name, receivedMessagesCount);
                        }
                        break;

                    case "Message":
                        string sender = input[1];

                        sentMessages[sender]++;

                        int messageCountSender = sentMessages[sender];

                        int messageReceivedCountSender = receivedMessages[sender];

                        string recipient = input[2];

                        receivedMessages[recipient]++;

                        int recipientMessegesSent = receivedMessages[recipient];

                        int recipientMessegesSentCount = sentMessages[recipient];

                        if (sentMessages.ContainsKey(recipient) &&
                            receivedMessages.ContainsKey(recipient))
                        {
                            if (messageCountSender >= capacity)
                            {
                                Console.WriteLine($"{sender} reached the capacity!");

                                sentMessages.Remove(sender);

                                receivedMessages.Remove(sender);
                            }
                            else if (recipientMessegesSent >= capacity)
                            {
                                Console.WriteLine($"{recipient} reached the capacity!");

                                sentMessages.Remove(recipient);

                                receivedMessages.Remove(recipient);
                            }
                            else if (messageCountSender + messageReceivedCountSender >= capacity)
                            {
                                Console.WriteLine($"{sender} reached the capacity!");

                                sentMessages.Remove(sender);

                                receivedMessages.Remove(sender);
                            }
                            else if (recipientMessegesSent + recipientMessegesSentCount >= capacity)
                            {
                                Console.WriteLine($"{recipient} reached the capacity!");

                                sentMessages.Remove(recipient);

                                receivedMessages.Remove(recipient);
                            }
                        }
                        break;

                    case "Empty":
                        if (input[1] != "All")
                        {
                            string usernameForDelete = input[1];

                            if (sentMessages.ContainsKey(usernameForDelete) &&
                                receivedMessages.ContainsKey(usernameForDelete))
                            {
                                sentMessages.Remove(usernameForDelete);
                                receivedMessages.Remove(usernameForDelete);
                            }
                        }
                        else
                        {
                            sentMessages.Clear();

                            receivedMessages.Clear();
                        }

                        break;

                    default:
                        break;
                }

                input = Console.ReadLine()
                .Split("=", StringSplitOptions.RemoveEmptyEntries);
            }

            StringBuilder sb = new StringBuilder();

            int usersCount = 0;

            if (sentMessages.Count > receivedMessages.Count)
            {
                usersCount = sentMessages.Count;
            }
            else if (sentMessages.Count <= receivedMessages.Count)
            {
                usersCount = receivedMessages.Count;
            }
            

            sb.AppendLine($"Users count: {usersCount}");

            foreach (var user in receivedMessages
                .OrderByDescending(u => u.Value)
                .ThenBy(u => u.Key))
            {
                string username = user.Key;
                int totalMessages = user.Value + sentMessages[username];

                sb.AppendLine($"{username} - {totalMessages}");
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}