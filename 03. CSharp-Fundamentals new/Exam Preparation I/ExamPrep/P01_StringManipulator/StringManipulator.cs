namespace P01_StringManipulator
{
    using System;

    public class StringManipulator
    {
        static void Main()
        {
            string text = Console.ReadLine();

            string[] commandsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandsInput[0];

            while (command != "End")
            {
                switch (command)
                {
                    case "Translate":
                        char symbol = char.Parse(commandsInput[1]);
                        char replacement = char.Parse(commandsInput[2]);
                        text = text.Replace(symbol, replacement);
                        Console.WriteLine(text);
                        break;

                    case "Includes":
                        string stringForCheck = commandsInput[1];
                        if (text.Contains(stringForCheck))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;

                    case "Start":
                        string firstString = commandsInput[1];
                        if (text.StartsWith(firstString))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;

                    case "Lowercase":
                        text = text.ToLower();
                        Console.WriteLine(text);
                        break;

                    case "FindIndex":
                        char letter = char.Parse(commandsInput[1]);
                        int index = text.LastIndexOf(letter);
                        Console.WriteLine(index);
                        break;

                    case "Remove":
                        int startIndex = int.Parse(commandsInput[1]);
                        int count = int.Parse(commandsInput[2]);
                        string removedText = text.Remove(startIndex, count);
                        Console.WriteLine(removedText);
                        break;

                    default:
                        break;
                }

                commandsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                command = commandsInput[0];
            }
        }
    }
}