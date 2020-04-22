namespace P09_PalindromeIntegers
{
    using System;

    public class PalindromeIntegers
    {
        static void Main()
        {
            string positive = "true";

            string negative = "false";
            
            string input = Console.ReadLine();

            while (input.ToUpper() != "END")
            {
                string result = String.Empty;

                bool palindome = IsPalindome(input);

                if (palindome == true)
                {
                    Console.WriteLine(positive);
                }
                else
                {
                    Console.WriteLine(negative);
                }

                input = Console.ReadLine();
            }
        }
        
        private static bool IsPalindome(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != number[number.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}