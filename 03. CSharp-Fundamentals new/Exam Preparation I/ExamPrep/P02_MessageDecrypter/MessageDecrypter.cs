namespace P02_MessageDecrypter
{
    using System;
    using System.Text.RegularExpressions;

    public class MessageDecrypter
    {
        static void Main()
        {
            string notVaidMessage = "Valid message not found!";

            string pattern =
                @"^([$%])([A-Z][a-z]{2,})([$%])\:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";

            int count = int.Parse(Console.ReadLine());

            while (count > 0)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string openingTag = match.Groups[1].Value;

                    string closingTag = match.Groups[3].Value;

                    if (openingTag == closingTag)
                    {
                        string tagName = match.Groups[2].Value;

                        string messsage = String.Empty;

                        for (int i = 4; i < match.Groups.Count; i++)
                        {
                            int val = int.Parse(match.Groups[i].Value);

                            messsage += (char)val;
                        }

                        Console.WriteLine($"{tagName}: {messsage}");
                    }
                    else
                    {
                        Console.WriteLine(notVaidMessage);
                    }

                }
                else
                {
                    Console.WriteLine(notVaidMessage);
                }

                count--;
            }
        }
    }
}