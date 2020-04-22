namespace P01_Username
{
    using System;

    public class Username
    {
        static void Main()
        {
            string username = Console.ReadLine();

            string commands = Console.ReadLine();

            while (commands != "Sign up")
            {
                string[] commandsArray = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandsArray[0];

                switch (command)
                {
                    case "Case":

                        string lowerOrUpper = commandsArray[1];

                        if (lowerOrUpper == "lower")
                        {
                            username = username.ToLower();

                            Console.WriteLine(username);
                        }
                        else if (lowerOrUpper == "upper")
                        {
                            username = username.ToUpper();

                            Console.WriteLine(username);
                        }
                        break;

                    case "Reverse":

                        int startIndex = int.Parse(commandsArray[1]);
                        int endIndex = int.Parse(commandsArray[2]);

                        bool inRange = username.Length > startIndex &&
                                       username.Length > endIndex &&
                                       startIndex < endIndex;

                        if (inRange)
                        {
                            int reverseLenght = endIndex - startIndex;

                            char[] usernameArray = username.ToCharArray();

                            Array.Reverse(usernameArray, startIndex, reverseLenght + 1);

                            string usernameRevercedString = new string(usernameArray);

                            string usernameForPrint = usernameRevercedString
                                .Substring(startIndex, reverseLenght + 1);

                            Console.WriteLine(usernameForPrint);
                        }
                        break;

                    case "Cut":
                        string substring = commandsArray[1];

                        if (username.Contains(substring))
                        {
                            username = username.Replace(substring, "");

                            Console.WriteLine(username);
                        }
                        else
                        {
                            Console.WriteLine($"The word {username} doesn't contain {substring}.");
                        }
                        break;

                    case "Replace":
                        char letter = char.Parse(commandsArray[1]);
                        char replacement = '*';

                        if (username.Contains(letter))
                        {
                            username = username.Replace(letter, replacement);
                         
                            Console.WriteLine(username);
                        }
                        break;

                    case "Check": 
                        char symbol = char.Parse(commandsArray[1]);

                        if (username.Contains(symbol))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {symbol}.");
                        }
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine();
            }
        }
    }
}