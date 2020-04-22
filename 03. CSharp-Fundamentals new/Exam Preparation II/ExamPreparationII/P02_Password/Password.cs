namespace P02_Password
{
    using System;
    using System.Text.RegularExpressions;

    public class Password
    {
        static void Main()
        {

            string pattern = @"^(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<(\1)$";

            Regex regex = new Regex(pattern);

            string wrongPassword = "Try another password!";

            string password = "Password: ";

            int count = int.Parse(Console.ReadLine());
             

            while (count > 0)
            {
                string passwordInput = Console.ReadLine();

                Match match = regex.Match(passwordInput);

                if (!match.Success)
                {
                    Console.WriteLine(wrongPassword);
                }
                else
                {
                    string numbers = match.Groups[2].Value;
                    string lowerLetters = match.Groups[3].Value;
                    string upperLetters = match.Groups[4].Value;
                    string symbols = match.Groups[5].Value;

                    Console.WriteLine($"{password}{numbers}{lowerLetters}{upperLetters}{symbols}");
                }

                count--;
            }
        }
    }
}