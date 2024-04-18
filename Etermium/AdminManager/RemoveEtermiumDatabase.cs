using MySqlConnector;
using System;
using System.Threading;

namespace Etermium.AdminManager;

/// <summary>
/// Abstract class for removing the Etermium database.
/// </summary>
public abstract class RemoveEtermiumDatabase
{
    public static string? Message { get; private set; }

    /// <summary>
    /// Removes the Etermium database and associated user.
    /// </summary>
    /// <param name="connection">The MySqlConnection object representing the database connection.</param>
    /// <returns>True if the database and user are successfully removed; otherwise, false.</returns>
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