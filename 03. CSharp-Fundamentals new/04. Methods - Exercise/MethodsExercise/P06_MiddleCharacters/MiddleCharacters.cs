namespace P06_MiddleCharacters
{
    using System;

    public class MiddleCharacters
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Console.WriteLine(GetMiddleCharacter(input));
        }

        static string GetMiddleCharacter(string input)
        {
            int lenght = input.Length;

            string result = "";

            if (lenght % 2 != 0)
            {
                result = input[input.Length / 2].ToString();
            }
            else
            {
                result = input[input.Length / 2 - 1].ToString() + 
                         input[input.Length / 2].ToString();
            }

            return result;
        }
    }
}