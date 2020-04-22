namespace P08_CompanyUsers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CompanyUsers
    {
        static void Main()
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            string[] input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                string name = input[0];
                string userId = input[1];

                if (!companies.ContainsKey(name))
                {
                    List<string> usersIds = new List<string>();
                    usersIds.Add(userId);

                    companies.Add(name, usersIds);
                }
                else
                {
                    if (!companies[name].Contains(userId))
                    {
                        companies[name].Add(userId);
                    }                    
                }
                               
                input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var company in companies)
            {
                sb.AppendLine($"{company.Key}");

                foreach (var user in company.Value)
                {
                    sb.AppendLine($"-- {user}");
                }
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}