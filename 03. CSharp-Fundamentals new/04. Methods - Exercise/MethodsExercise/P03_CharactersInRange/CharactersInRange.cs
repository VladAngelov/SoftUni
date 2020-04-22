namespace P03_CharactersInRange
{
    using System;
    using System.Text;

    public class CharactersInRange
    {
        static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            
            char secondChar = char.Parse(Console.ReadLine());

            Console.WriteLine(GetAllsymbols(firstChar, secondChar));
        }

        private static string GetAllsymbols(char firstChar, char secondChar)
        {
            int firstIndex = (int)firstChar;

            int secondIndex = (int)secondChar;

            StringBuilder sb = new StringBuilder();
            
            if (firstIndex < secondIndex)
            {
                for (int i = firstIndex + 1; i < secondIndex; i++)
                {
                    sb.Append((char)i + " ");
                }
            }
            else if (firstIndex > secondIndex)
            {
                for (int i = secondIndex + 1; i < firstIndex; i++)
                {
                    sb.Append((char)i + " ");
                }
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}