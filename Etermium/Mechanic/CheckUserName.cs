using MySqlConnector;
using System;
using System.Threading;
using Etermium.Start_Config;

namespace Etermium.Mechanic;

/// <summary>
/// Abstract class for checking the uniqueness of a player's username and creating a new player in the database.
/// </summary>
public abstract class CheckUserName
{
    private static readonly DatabaseConfig Config = new();

    /// <summary>
    /// Checks if the given player name is unique and creates a new player in the database if it is.
    /// </summary>
    /// <param name="playerName">The name of the player to be checked.</param>
    /// <param name="password">The password associated with the player's account.</param>
    /// <returns>True if the player name is unique and the player is successfully created; otherwise, false.</returns>
    public static bool CheckSameName(string playerName, string? password)
    {
        if (playerName.Length is < 5 or > 50)
        {
            Console.WriteLine("Zadané jméno je mimo rozsah.");
            Thread.Sleep(2000);
            return false;
        }

        if (password!.Length < 8)
        {
            Console.WriteLine("Zadané heslo je mimo rozsah.");
            Thread.Sleep(2000);
            return false;
        }

        try
        {
            const string query = "select PlayerName from Users;";
            using (MySqlCommand command = new MySqlCommand(query, Config.StableConnect()))
            {
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();
                while (reader.Read())
                    if (reader[0].ToString()?.ToLower() == playerName.ToLower())
                    {
                        Console.WriteLine("Toto jméno je již používané");
                        Thread.Sleep(2000);
                        return false;
                    }

                var hashPassword = Md5Hash.CalculateMd5Hash(password);
                CreatePlayerTable(playerName, hashPassword);
            }

            Console.WriteLine("Postava úspěšně vytvořena!");
            Thread.Sleep(2000);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Chyba při ověření uživatele z databáze: {e.Message}");
            return false;
        }
    }

    /// <summary>
    /// Creates a new player table in the database with the specified player name and hashed password.
    /// </summary>
    /// <param name="playerName">The name of the player for whom to create a new table.</param>
    /// <param name="hashPassword">The hashed password associated with the player's account.</param>
    private static void CreatePlayerTable(string playerName, string hashPassword)
    {
        try
        {
            var query =
                $"insert into Users(PlayerName, Password) values(@user, @password);\ncreate table if not exists {playerName}(id int auto_increment primary key, Hp int, Mana int, AttackPower int, Money int, HpPotion int, PowerPotion int, Created datetime default NOW(), PlayerName nvarchar(55));";

            using (MySqlCommand command = new MySqlCommand(query, Config.StableConnect()))
            {
                command.Parameters.AddWithValue("@user", playerName);
                command.Parameters.AddWithValue("@password", hashPassword);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Není spuštěna databáze, přečti si README ve složce se hrou, error: {e.Message}");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}