namespace P01_ExperienceGaining
{
    using System;

    public class ExperienceGaining
    {
        static void Main()
        {
            double amountOfExperience = double.Parse(Console.ReadLine());

            int countOfBattles = int.Parse(Console.ReadLine());

            double totalExp = 0.0;

            int count = 0;
            
            for (int i = 1; i <= countOfBattles; i++)
            {
                double experience = double.Parse(Console.ReadLine());

                totalExp += experience;

                if (i % 3 == 0)
                {
                    totalExp += experience * 0.15;
                }

                if (i % 5 == 0)
                {
                    totalExp -= experience * 0.1;
                }

                count++;

                if (totalExp >= amountOfExperience)
                {
                    string successMessage =
                        $"Player successfully collected his needed experience for {count} battles.";

                    Console.WriteLine(successMessage);

                    return;
                }
            }

            double neededExperience = amountOfExperience - totalExp;

            string failMassage = $"Player was not able to collect the needed experience, {neededExperience:f2} more needed.";

            if (totalExp < amountOfExperience)
            {
                Console.WriteLine(failMassage);
            }
        }
    }
}