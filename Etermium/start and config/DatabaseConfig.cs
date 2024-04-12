namespace Etermium.start_and_config;

using MySqlConnector;

public class DatabaseConfig
{
    private MySqlConnection _firstConnection = null!;
    private MySqlConnection _stableConnection = null!;

    public MySqlConnection FirstOrLastConnect()
    {
        uint attempt = 3;
        while (attempt != 0)
        {
            try
            {
                string? file;
                using (StreamReader streamReader = new StreamReader(@"Data\Config\config.txt"))
                {
                    file = streamReader.ReadToEnd();
                }

                _firstConnection = new MySqlConnection(file);
                _firstConnection.Open();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection attempt: {attempt}");
                attempt--;
                Thread.Sleep(1000);
                if (attempt == 0)
                {
                    Console.WriteLine($"Database not found, not started, or error occurred: {ex.Message}");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
            }
        }

        return _firstConnection;
    }

    public void CreateDatabase()
    {
        try
        {
            var createDatabaseQuery =
                "CREATE DATABASE if not exists Etermium; \nCREATE USER if not exists 'EtermiumUser'@'%' IDENTIFIED BY 'etermium'; \nGRANT ALL PRIVILEGES ON etermium.* TO 'EtermiumUser'@'%'; \nFLUSH PRIVILEGES;";
            using (MySqlCommand command = new MySqlCommand(createDatabaseQuery, FirstOrLastConnect()))
            {
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database not found, not started, or error occurred: {ex.Message}");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }
    }

    public MySqlConnection StableConnect()
    {
        uint attempt = 3;
        while (attempt != 0)
        {
            try
            {
                _stableConnection =
                    new MySqlConnection("Server=127.0.0.1;Database=etermium;User ID=EtermiumUser;Password=etermium;");
                _stableConnection.Open();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection attempt: {attempt}");
                attempt--;
                Thread.Sleep(1000);
                if (attempt == 0)
                {
                    Console.WriteLine($"Database not found, not started, or error occurred: " + ex.Message);
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
            }
        }

        return _stableConnection;
    }

    public void ImportData()
    {
        try
        {
            const string query =
                "create table if not exists Users(id int auto_increment primary key, PlayerName nvarchar(55), Password nvarchar(1000), Created datetime default NOW());";
            using (MySqlCommand command = new MySqlCommand(query, StableConnect()))
            {
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Import data error: {e.Message}");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }
    }
}