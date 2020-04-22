namespace P02_Registration
{
    using System;
    using System.Text.RegularExpressions;

    public class Registration
    {
        static void Main()
        {
            string badInput = "Invalid username or password";

            string successRegistrartion = "Registration was successful";

            string successfulRegistred = "Successful registrations: ";

            string pattern = @"^(U\$)([A-Z][a-z]{2,})(\1)([P]\@\$)([A-Za-z]{5,}[\d]+)(\4)$";

            Regex regex = new Regex(pattern);

            int loops = int.Parse(Console.ReadLine());

            int count = 0;

            while (loops > 0)
            {
                string usernameAndPassword = Console.ReadLine();

                Match match = regex.Match(usernameAndPassword);

                if (!match.Success)
                {
                    Console.WriteLine(badInput);
                }
                else
                {
                    Console.WriteLine(successRegistrartion);

                    string username = match.Groups[2].Value;
                    string password = match.Groups[5].Value;

                    Console.WriteLine($"Username: {username}, Password: {password}");

                    count++;
                }

                loops--;
            }

            Console.WriteLine(successfulRegistred + count);
        }
    }
}