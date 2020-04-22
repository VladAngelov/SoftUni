namespace P02_VowelsCount
{
    using System;

    public class VowelsCount
    {
        static void Main()
        {
            string text = Console.ReadLine().ToLower();

            Console.WriteLine(VowelsCountMethod(text));
        }

        private static int VowelsCountMethod(string text)
        {
            int count = 0;

            char[] vowels = new char[]
            {
                'a', 'e', 'i',
                'o', 'u', 'y'
            };

            foreach (char symbol in text)
            {
                if (symbol == vowels[0] ||
                    symbol == vowels[1] ||
                    symbol == vowels[2] ||
                    symbol == vowels[3] ||
                    symbol == vowels[4] ||
                    symbol == vowels[5])
                {   
                    count++;
                }
            }

            return count;
        }
    }
}