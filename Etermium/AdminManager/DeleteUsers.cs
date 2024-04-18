using MySqlConnector;
using System;
using System.Threading;

namespace Etermium.AdminManager;

/// <summary>
/// Abstract class for deleting user data from the database.
/// </summary>
public abstract class DeleteUsers
{
    /// <summary>
    /// Deletes a user and associated data from the database.
    /// </summary>
    /// <param name="connection">The MySqlConnection object representing the database connection.</param>
    /// <param name="playerName">The name of the player whose data is to be deleted.</param>
    /// <returns>True if the user and associated data are successfully deleted; otherwise, false.</returns>
    public static bool DeleteUser(MySqlConnection connection, string playerName)
    {
        try
        {
            const string deleteUserQuery = "DELETE FROM Users WHERE Playername = @PlayerName";
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