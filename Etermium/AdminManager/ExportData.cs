using MySqlConnector;
using System;
using System.IO;
using System.Threading;
using Etermium.Start_Config;

namespace Etermium.AdminManager;

/// <summary>
/// Handles exporting user data to a CSV file.
/// </summary>
public class ExportData
{
    private readonly DatabaseConfig _config = new();
    public static string? Message { get; set; }

    /// <summary>
    /// Exports user data from the database to a CSV file.
    /// </summary>
    /// <returns>True if the export is successful; otherwise, false.</returns>
    public bool Export()
    {
        const string query = "select * from users";

        using (MySqlCommand command = new MySqlCommand(query, _config.StableConnect()))
        {
            try
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    using (StreamWriter writer = new StreamWriter(@"Data\export.csv"))
                    {
                        writer.WriteLine("ID,PlayerName,Password,Created");
                        while (reader.Read())
                        {
                            var id = reader["id"];
                            var playerName = reader["PlayerName"];
                            var password = reader["Password"];
                            var created = reader["Created"];

                            writer.WriteLine($"{id},{playerName},{password},{created}");
                        }

                        writer.WriteLine("ID,PlayerName,Password,Created");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }
    }
}