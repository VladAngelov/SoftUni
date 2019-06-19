namespace Problem3
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

                // 01
                int id = int.Parse(Console.ReadLine());

                string sqlQuery = @"SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    string villainName = (string)command.ExecuteScalar();

                    if (string.IsNullOrEmpty(villainName))
                    {
                        Console.WriteLine("No villain with ID 10 exists in the database.");
                        return;
                    }

                    Console.WriteLine(villainName);
                }

                // 02
                string sqlQuery2 = @" SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(sqlQuery2, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long rowNum = (long)reader["RowNum"];

                            string mName = (string)reader["Name"];

                            int mAge = (int)reader["Age"];


                            Console.WriteLine($"{rowNum} {mName} {mAge}");
                        }
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
            }
        }
    }
}