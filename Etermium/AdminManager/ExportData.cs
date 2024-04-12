using Etermium.start_and_config;
using MySqlConnector;

namespace Etermium.AdminManager;

public class ExportData
{
    private DatabaseConfig _config = new();
    public static string? Message { get; set; }

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