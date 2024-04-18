using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Etermium.AdminManager;

/// <summary>
/// Abstract class for displaying all users in the database.
/// </summary>
public abstract class ShowAllUsers
{
    /// <summary>
    /// Displays all users in the database.
    /// </summary>
    /// <param name="connect">The MySqlConnection object representing the database connection.</param>
    public static void ShowAllUserss(MySqlConnection connect)
    {
        try
        {
            const string query = "select * from Users";

            using (MySqlCommand command = new MySqlCommand(query, connect))
            {
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                var id = new List<int>();
                while (reader.Read())
                {
                    Console.WriteLine("=============================\nID: " + reader[0] + "\nPlayerName: " + reader[1] +
                                      ", Password: " + reader[2] + ", Created at: " + reader[3]);
                    id.Add(int.Parse(reader[0].ToString()!));
                }

                if (id.Count == 0)
                {
                    Console.WriteLine("Nenalezen žádný hráč.");
                    Thread.Sleep(2000);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}