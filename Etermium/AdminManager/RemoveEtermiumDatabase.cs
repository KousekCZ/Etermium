using MySqlConnector;

namespace Etermium.AdminManager;

public abstract class RemoveEtermiumDatabase
{
    public static string? Message { get; private set; }

    public static bool RemoveDatabase(MySqlConnection connection)
    {
        try
        {
            const string deleteUserQuery = "Drop database etermium";
            using (MySqlCommand deleteUserCommand = new MySqlCommand(deleteUserQuery, connection))
            {
                deleteUserCommand.ExecuteNonQuery();
            }

            const string dropTableQuery = "DROP USER 'EtermiumUser'@'%';";
            using (MySqlCommand dropTableCommand = new MySqlCommand(dropTableQuery, connection))
            {
                dropTableCommand.ExecuteNonQuery();
            }

            return true;
        }
        catch (Exception e)
        {
            Message = e.Message;
            return false;
        }
    }
}