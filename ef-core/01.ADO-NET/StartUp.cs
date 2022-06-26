using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Data.SqlClient;

namespace AdoNetExerciseSolutions
{
    public class StartUp
    {
        public static void Main()
        {
            using SqlConnection connection = new SqlConnection(Config.ConnectionString);

            connection.Open();

            Console.WriteLine($"{GetVillainNamesWithMinionsCount(connection)}\n");

            int villianId = int.Parse(Console.ReadLine());
            Console.WriteLine($"{GetVillainWithMinions(connection, villianId)}\n");

            string[] minionInfo = Console.ReadLine().Split();
            string[] villainName = Console.ReadLine().Split();
            Console.WriteLine($"{AddNewMinion(connection, minionInfo, villainName)}\n");

            string countryName = Console.ReadLine();
            Console.WriteLine($"{ChangeTownNameCasing(connection, countryName)}\n");

            int villianIdToDelete = int.Parse(Console.ReadLine());
            Console.WriteLine($"{DeleteVillain(connection, villianIdToDelete)}\n");

            Console.WriteLine($"{PrintAllNames(connection)}\n");

            int[] minionsIds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine($"{IncreaseMinionsAge(connection, minionsIds)}\n");

            int minionIds = int.Parse(Console.ReadLine());
            Console.WriteLine($"{IncreaseMinionAge(connection, minionIds)}\n");

            connection.Close();
        }

        // Problem 02 - Villain Names
        private static string GetVillainNamesWithMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string query = @"SELECT [v].[Name]
                                  , COUNT([mv].[VillainId]) AS MinionsCount  
                               FROM [Villains] AS [v] 
                               JOIN [MinionsVillains] AS [mv] 
	                             ON [v].[Id] = [mv].[VillainId] 
                           GROUP BY [v].[Name] 
                             HAVING COUNT([mv].[VillainId]) > 3 
                           ORDER BY [MinionsCount] DESC";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

            return sb.ToString().Trim();
        }

        // Problem 03 - Minion Names
        private static string GetVillainWithMinions(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            string villainNameQuery = @"SELECT [Name]
                                          FROM [Villains]
                                         WHERE [Id] = @villainId";

            SqlCommand getVillainNameCmd = new SqlCommand(villainNameQuery, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@villainId", villainId);

            string villainName = (string)getVillainNameCmd.ExecuteScalar();
            if (villainName == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            sb.AppendLine($"Villain: {villainName}");

            string minionsQuery = @"SELECT [m].[Name]
                                         , [m].[Age]
                                      FROM [Villains] AS [v]
                                 LEFT JOIN [MinionsVillains] AS [mv]
                                        ON [v].[Id] = [mv].[VillainId]
                                 LEFT JOIN [Minions] AS [m]
                                        ON [m].[Id] = [mv].[MinionId]
                                     WHERE [mv].[VillainId] = @villainId
                                  ORDER BY [m].[Name]";

            SqlCommand getMinionsCmd = new SqlCommand(minionsQuery, sqlConnection);
            getMinionsCmd.Parameters.AddWithValue("@villainId", villainId);

            using SqlDataReader reader = getMinionsCmd.ExecuteReader();
            if (!reader.HasRows)
            {
                sb.AppendLine($"(no minions)");
            }
            else
            {
                int rowNum = 1;
                while (reader.Read())
                {
                    sb.AppendLine($"{rowNum++}. {reader["Name"]} {reader["Age"]}");
                }
            }

            return sb.ToString().Trim();
        }

        // Problem 04 - Add Minion
        private static string AddNewMinion(SqlConnection sqlConnection, string[] minionInfo, string[] villainName)
        {
            StringBuilder sb = new StringBuilder();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                int townId = GetTownId(sqlConnection, sqlTransaction, sb, townName);
                int villainId = GetVillainId(sqlConnection, sqlTransaction, sb, villainName[1]);
                int minionId = AddMinionAndGetId(sqlConnection, sqlTransaction, minionName, minionAge, townId);

                string addMinionToVillainQuery = @"INSERT INTO [MinionsVillains]([MinionId], [VillainId])
                                                        VALUES (@minionId, @villainId)";
                SqlCommand addMinionToVillainCmd = new SqlCommand(addMinionToVillainQuery, sqlConnection, sqlTransaction);
                addMinionToVillainCmd.Parameters.AddWithValue("@minionId", minionId);
                addMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                addMinionToVillainCmd.ExecuteNonQuery();
                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName[1]}.");

                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.ToString();
            }

            return sb.ToString().Trim();
        }

        // Problem 04 Helper Method 01
        private static int GetTownId(
            SqlConnection sqlConnection,
            SqlTransaction sqlTransaction,
            StringBuilder sb,
            string townName)
        {
            string townIdQuery = @"SELECT [Id] 
                                     FROM [Towns] 
                                    WHERE [Name] = @townName";
            SqlCommand townIdCmd = new SqlCommand(townIdQuery, sqlConnection, sqlTransaction);
            townIdCmd.Parameters.AddWithValue("@townName", townName);

            object townIdObj = townIdCmd.ExecuteScalar();
            if (townIdObj == null)
            {
                string addTownQuery = @"INSERT INTO [Towns] ([Name]) 
                                             VALUES (@townName)";
                SqlCommand addTownCmd = new SqlCommand(addTownQuery, sqlConnection, sqlTransaction);
                addTownCmd.Parameters.AddWithValue("@townName", townName);
                addTownCmd.ExecuteNonQuery();

                sb.AppendLine($"Town {townName} was added to the database.");
                townIdObj = townIdCmd.ExecuteScalar();
            }

            return (int)townIdObj;
        }

        // Problem 04 Helper Method 02
        private static int GetVillainId(
            SqlConnection sqlConnection,
            SqlTransaction sqlTransaction,
            StringBuilder sb,
            string villainName)
        {
            string villainIdQuery = @"SELECT [Id]
                                        FROM [Villains]
                                       WHERE [Name] = @name";
            SqlCommand villainIdCmd = new SqlCommand(villainIdQuery, sqlConnection, sqlTransaction);
            villainIdCmd.Parameters.AddWithValue("@name", villainName);

            object villainIdObj = villainIdCmd.ExecuteScalar();
            if (villainIdObj == null)
            {
                string evilnessFactorQuery = @"SELECT [Id]
                                                 FROM [EvilnessFactors]
                                                WHERE [Name] = 'Evil'";
                SqlCommand evilnessFactorCmd = new SqlCommand(evilnessFactorQuery, sqlConnection, sqlTransaction);
                int evilnessFactorId = (int)evilnessFactorCmd.ExecuteScalar();

                string insertVillainQuery = @"INSERT INTO [Villains]([Name], [EvilnessFactorId])
                                                   VALUES (@villainName, @evilnessFactorId)";
                SqlCommand insertVillainCmd = new SqlCommand(insertVillainQuery, sqlConnection, sqlTransaction);
                insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                insertVillainCmd.Parameters.AddWithValue("@evilnessFactorId", evilnessFactorId);

                insertVillainCmd.ExecuteNonQuery();
                sb.AppendLine($"Villain {villainName} was added to the database.");

                villainIdObj = villainIdCmd.ExecuteScalar();
            }

            return (int)villainIdObj;
        }

        // Problem 04 Helper Method 03
        private static int AddMinionAndGetId(
            SqlConnection sqlConnection,
            SqlTransaction sqlTransaction,
            string minionName,
            int minionAge,
            int townId)
        {
            string addMinionQuery = @"INSERT INTO [Minions] ([Name], [Age], [TownId])
                                           VALUES (@name, @age, @townId)";
            SqlCommand addMinionCmd = new SqlCommand(addMinionQuery, sqlConnection, sqlTransaction);
            addMinionCmd.Parameters.AddWithValue("@name", minionName);
            addMinionCmd.Parameters.AddWithValue("@age", minionAge);
            addMinionCmd.Parameters.AddWithValue("@townId", townId);

            addMinionCmd.ExecuteNonQuery();

            string addedMinionIdQuery = @"SELECT [Id]
                                            FROM [Minions]
                                           WHERE [Name] = @name 
                                             AND [Age] = @age 
                                             AND [TownId] = @townId";
            SqlCommand getMinionIdCmd = new SqlCommand(addedMinionIdQuery, sqlConnection, sqlTransaction);
            getMinionIdCmd.Parameters.AddWithValue("@name", minionName);
            getMinionIdCmd.Parameters.AddWithValue("@age", minionAge);
            getMinionIdCmd.Parameters.AddWithValue("@townId", townId);

            int minionId = (int)getMinionIdCmd.ExecuteScalar();

            return minionId;
        }

        // Problem 05 - Change Town Names Casing
        private static string ChangeTownNameCasing(SqlConnection sqlConnection, string countryName)
        {
            StringBuilder sb = new StringBuilder();

            string updateTownsQuery = @"UPDATE [Towns]
                                           SET [Name] = UPPER([Name])
                                         WHERE [CountryCode] = (
                                                                SELECT [c].[Id] 
						                                          FROM [Countries] AS [c] 
						                                         WHERE [c].[Name] = @countryName
					                                           )";
            SqlCommand updateTownsCmd = new SqlCommand(updateTownsQuery, sqlConnection);
            updateTownsCmd.Parameters.AddWithValue("@countryName", countryName);

            int changedRows = updateTownsCmd.ExecuteNonQuery();
            sb.AppendLine($"{changedRows} town names were affected.");

            string getChangedTownsQuery = @"SELECT [t].[Name] 
                                              FROM [Towns] as [t]
                                              JOIN [Countries] AS [c] 
                                                ON [c].[Id] = [t].[CountryCode]
                                             WHERE [c].[Name] = @countryName";
            SqlCommand getChangedTownsCmd = new SqlCommand(getChangedTownsQuery, sqlConnection);
            getChangedTownsCmd.Parameters.AddWithValue("@countryName", countryName);

            string[] changedTowns = new string[changedRows];
            int i = 0;
            using SqlDataReader reader = getChangedTownsCmd.ExecuteReader();
            while (reader.Read())
            {
                changedTowns[i++] = (string)reader["Name"];
            }

            sb.AppendLine($"[{string.Join(", ", changedTowns)}]");

            return sb.ToString().Trim();
        }

        // Problem 06 - Remove Villains
        private static string DeleteVillain(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            string villainNameQuery = @"SELECT [Name]
                                          FROM [Villains]
                                         WHERE [Id] = @villainId";
            SqlCommand villainNameCmd = new SqlCommand(villainNameQuery, sqlConnection);
            villainNameCmd.Parameters.AddWithValue("@villainId", villainId);

            string villainName = (string)villainNameCmd.ExecuteScalar();
            if (villainName == null)
            {
                return $"No such villain was found.";
            }

            SqlTransaction transaction = sqlConnection.BeginTransaction();
            try
            {
                string releaseMinionsQuery = @"DELETE FROM [MinionsVillains]
                                                     WHERE [VillainId] = @villainId";
                SqlCommand releaseMinionsCmd = new SqlCommand(releaseMinionsQuery, sqlConnection, transaction);
                releaseMinionsCmd.Parameters.AddWithValue("@villainId", villainId);

                int minionsReleased = releaseMinionsCmd.ExecuteNonQuery();

                string deleteVillainQuery = @"DELETE FROM [Villains]
                                                    WHERE [Id] = @villainId";
                SqlCommand deleteVillainCmd =new SqlCommand(deleteVillainQuery, sqlConnection, transaction);
                deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                int villainsDeleted = deleteVillainCmd.ExecuteNonQuery();

                if (villainsDeleted != 1)
                {
                    transaction.Rollback();
                }

                sb.AppendLine($"{villainName} was deleted.")
                  .AppendLine($"{minionsReleased} minions were released.");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return e.ToString();
            }

            transaction.Commit();

            return sb.ToString().Trim();
        }

        // Problem 07 - Print All Minion Names
        private static string PrintAllNames(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string selectMinionsQuery = @"SELECT [Name]
                                            FROM [Minions]";
            SqlCommand selectMinionsCmd = new SqlCommand(selectMinionsQuery, sqlConnection);

            List<string> minionsNames = new List<string>();
            using SqlDataReader reader = selectMinionsCmd.ExecuteReader();
            while (reader.Read())
            {
                minionsNames.Add((string)reader["Name"]);
            }

            for (int i = 0; i < minionsNames.Count / 2; i++)
            {
                sb.AppendLine(minionsNames[i]);
                sb.AppendLine(minionsNames[minionsNames.Count - (1 + i)]);
            }

            return sb.ToString().Trim();
        }

        // Problem 08 - Increase Minion Age
        private static string IncreaseMinionsAge(SqlConnection sqlConnection, int[] minionIds)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int id in minionIds)
            {
                string updateMinionsByIdQuery = @"UPDATE [Minions]
                                                     SET [Name] = UPPER(LEFT([Name], 1)) + SUBSTRING([Name], 2, LEN([Name]))
	                                                   , [Age] += 1
                                                   WHERE [Id] = @id";
                SqlCommand updateMinionsByIdCmd = new SqlCommand(updateMinionsByIdQuery, sqlConnection);
                updateMinionsByIdCmd.Parameters.AddWithValue("@id", id);
                updateMinionsByIdCmd.ExecuteNonQuery();
            }

            string getMinionsNamesAndAgeQuery = @"SELECT [Name]
                                                       , [Age] 
                                                    FROM [Minions]";
            SqlCommand getMinionsNamesAndAgeCmd = new SqlCommand(getMinionsNamesAndAgeQuery, sqlConnection);

            using SqlDataReader reader = getMinionsNamesAndAgeCmd.ExecuteReader();
            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
            }

            return sb.ToString().Trim();
        }

        // Problem 09 - Increase Age Stored Procedure
        private static string IncreaseMinionAge(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder sb = new StringBuilder();

            string increaseAgeQuery = @"EXEC [dbo].[usp_GetOlder] @minionId";
            SqlCommand increaseAgeCmd = new SqlCommand(increaseAgeQuery, sqlConnection);
            increaseAgeCmd.Parameters.AddWithValue("@minionId", minionId);

            increaseAgeCmd.ExecuteNonQuery();

            string minionInfoQuery = @"SELECT [Name]
                                            , [Age]
                                         FROM [Minions]
                                        WHERE [Id] = @minionId";
            SqlCommand minionInfoCmd = new SqlCommand(minionInfoQuery, sqlConnection);
            minionInfoCmd.Parameters.AddWithValue("@minionId", minionId);

            using SqlDataReader reader = minionInfoCmd.ExecuteReader();
            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} – {reader["Age"]} years old");
            }

            return sb.ToString().Trim();
        }
    }
}
