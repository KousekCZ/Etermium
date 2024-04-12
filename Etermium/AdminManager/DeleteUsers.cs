using MySqlConnector;

namespace Etermium.AdminManager;

public class DeleteUsers
{
    public static bool DeleteUser(MySqlConnection connection, string playerName)
    {
        try
        {
            var deleteUserQuery = "DELETE FROM Users WHERE Playername = @PlayerName";
            using (MySqlCommand deleteUserCommand = new MySqlCommand(deleteUserQuery, connection))
            {
                deleteUserCommand.Parameters.AddWithValue("@PlayerName", playerName);
                deleteUserCommand.ExecuteNonQuery();
            }

            var dropTableQuery = $"DROP TABLE `{playerName}`";
            using (MySqlCommand dropTableCommand = new MySqlCommand(dropTableQuery, connection))
            {
                dropTableCommand.ExecuteNonQuery();
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}