namespace P01_EmailValidator
{
    using System;
    using System.Text;

    public class EmailValidator
    {
        static void Main()
        {
            string email = Console.ReadLine();

            char symbolForReplace = '-';

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            while (commands[0] != "Complete")
            {
                string command = commands[0];

                switch (command)
                {
                    case "Make":
                        if (commands[1] == "Upper")
                        {
                            email = email.ToUpper();

                            Console.WriteLine(email);
                        }
                        else if (commands[1] == "Lower")
                        {
                            email = email.ToLower();

                            Console.WriteLine(email);
                        }
                        break;

                    case "GetDomain":
                        int count = int.Parse(commands[1]);

                        int index = email.Length - count;

                        string domain = email.Substring(index, count);

                        Console.WriteLine(domain);
                        break;

                    case "GetUsername":
                        if (email.Contains("@"))
                        {
                            string[] username = email.Split("@");

                            Console.WriteLine(username[0]);
                        }
                        else
                        {
                            Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        }
                        break;

                    case "Replace":
                        char symbol = char.Parse(commands[1]);

                        //if (email.Contains(symbol))
                        //{
                        //    email = email.Replace(symbol, symbolForReplace);

                        //    Console.WriteLine(email);
                        //}

                        email = email.Replace(symbol, symbolForReplace);

                        Console.WriteLine(email);

                        break;

                    case "Encrypt":
                        char[] emailCharArray = email.ToCharArray();

                        StringBuilder sb = new StringBuilder();

                        foreach (char letter in emailCharArray)
                        {
                            int anciiLetter = (int)letter;

                            sb.Append(anciiLetter + " ");
                        }

                        string result = sb.ToString().TrimEnd();

                        Console.WriteLine(result);
                        break;

                    default:
                        break;
                }

                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}