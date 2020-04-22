namespace P02_CommonElements
{
    using System;
    using System.Text;

    public class CommonElements
    {
        static void Main()
        {
            string[] firstStrinig = Console.ReadLine().Split();

            string[] secondString = Console.ReadLine().Split();

            StringBuilder sb = new StringBuilder();

            foreach (var item in secondString)
            {
                foreach (var item2  in firstStrinig)
                {
                    if (item == item2)
                    {
                        sb.Append(item2 + " ");
                    }
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}