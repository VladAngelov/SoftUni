namespace P05_MonthPrinter
{
    using System;

    public class MonthPrinter
    {
        static void Main()
        {
            string error = "Error!";

            string january = "January";
            string february = "February";
            string march = "March";
            string april = "April";
            string may = "May";
            string june = "June";
            string july = "July";
            string august = "August";
            string september = "September";
            string october = "October";
            string november = "November";
            string december = "December";

            int month = int.Parse(Console.ReadLine());

            switch (month)
            {
                case 1:
                    Console.WriteLine(january);
                    break;

                case 2:
                    Console.WriteLine(february);
                    break;

                case 3:
                    Console.WriteLine(march);
                    break;

                case 4:
                    Console.WriteLine(april);
                    break;

                case 5:
                    Console.WriteLine(may);
                    break;

                case 6:
                    Console.WriteLine(june);
                    break;

                case 7:
                    Console.WriteLine(july);
                    break;

                case 8: Console.WriteLine(august); break;

                case 9:
                    Console.WriteLine(september);
                    break;

                case 10:
                    Console.WriteLine(october);
                    break;

                case 11:
                    Console.WriteLine(november);
                    break;

                case 12:
                    Console.WriteLine(december);
                    break;

                default:
                    Console.WriteLine(error);
                    break;
            }
        }
    }
}