namespace Problem2
{
    using System.Data.SqlClient;
    using AdoNetExercises;
    using System;

    public class StartUp
    {
        static void Main()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string sqlQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                GROUP BY v.Id, v.Name
                                    HAVING COUNT(mv.VillainId) > 3
                                ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string villainName = (string)reader["Name"];
                            int countMinions = (int) reader["MinionsCount"];

                            Console.WriteLine($"{villainName} - {countMinions}");
                        }
                    }
                }
            }
        }
    }
}