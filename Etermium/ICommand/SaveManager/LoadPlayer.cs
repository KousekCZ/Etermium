using Etermium.Entits;
using Etermium.Mechanic;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Threading;
using Etermium.Start_Config;

namespace Etermium.ICommand.SaveManager;

/// <summary>
/// Command to load a player's saved game position.
/// </summary>
public class LoadPlayer : ICommand
{
    private readonly DatabaseConfig _config = new();
    private bool _loginLoad;
    private string? _loginName;
    private string? _loginPassword;

    /// <summary>
    /// Executes the command to load the player's saved game position.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Load(player);
    }

    /// <summary>
    /// Prompts the user for login credentials and loads the player's saved game position if authentication succeeds.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <returns>True if the login was unsuccessful, false otherwise.</returns>
    public bool Login(Player player)
    {
        bool isChecking = true;
        var playerFound = false;
        while (isChecking)
        {
            Console.Write("Zadej přihlašovací jméno: ");
            _loginName = Console.ReadLine()!;
            Console.Write("Zadej přihlašovací heslo: ");
            _loginPassword = Console.ReadLine()!;
            _loginPassword = Md5Hash.CalculateMd5Hash(_loginPassword);

            try
            {
                var query = "select PlayerName, Password from Users;";

                using (MySqlCommand command = new MySqlCommand(query, _config.StableConnect()))
                {
                    command.ExecuteNonQuery();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader[0].ToString()?.ToLower() == _loginName.ToLower() &&
                            reader[1].ToString() == _loginPassword)
                        {
                            _loginLoad = true;
                            Load(player);
                            playerFound = true;
                            return false;
                        }
                    }

                    if (!playerFound)
                    {
                        Console.WriteLine("Jméno a heslo se neshodují nebo neexistují v databázi.\n");
                        Thread.Sleep(2000);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return false;
    }

    /// <summary>
    /// Loads the saved game positions from the database.
    /// </summary>
    /// <param name="player">The player object.</param>
    private void Load(Player player)
    {
        try
        {
            string query;

            if (_loginLoad)
            {
                query = $"select id, Hp, Mana, AttackPower, Money, HpPotion, PowerPotion, Created from {_loginName}";
            }
            else
            {
                query =
                    $"select id, Hp, Mana, AttackPower, Money, HpPotion, PowerPotion, Created from {player.PlayerName}";
            }

            using (MySqlCommand command = new MySqlCommand(query, _config.StableConnect()))
            {
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();

                var id = new List<int>();

                while (reader.Read())
                {
                    Console.WriteLine("------------------\nID: " + reader[0] + "\nHP: " + reader[1] +
                                      ", Mana: " + reader[2] + ", sila: " + reader[3] + ", peníze: " +
                                      reader[4] + ", lektvarHp: " + reader[5] + ", lektvarSila: " + reader[6] +
                                      "\nDatum vytvoření: " + reader[7]);
                    id.Add(int.Parse(reader[0].ToString()!));
                }

                if (id.Count == 0)
                {
                    Console.WriteLine("Nenalezen žádný save.");
                    Thread.Sleep(2000);
                }
                else
                {
                    LoadPosition(id, player);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Prompts the user to select a saved game position to load.
    /// </summary>
    /// <param name="id">The list of IDs of available saved game positions.</param>
    /// <param name="player">The player object.</param>
    private void LoadPosition(List<int> id, Player player)
    {
        var choose = 0;
        try
        {
            do
            {
                try
                {
                    Console.Write("\nZadej ID pozice, ktere chceš načíst (stiskni 0 pro ukončení): ");
                    choose = int.Parse(Console.ReadLine()!.Trim());

                    if (!id.Contains(choose) && choose != 0)
                    {
                        Console.WriteLine("\nTakova pozice s ID neexistuje.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!id.Contains(choose) && choose != 0);

            if (choose != 0)
            {
                string query;
                if (_loginLoad)
                {
                    query =
                        $"select id, Hp, Mana, AttackPower, Money, HpPotion, PowerPotion, PlayerName from {_loginName} where id = {choose}";
                }
                else
                {
                    query =
                        $"select id, Hp, Mana, AttackPower, Money, HpPotion, PowerPotion, PlayerName from {player.PlayerName} where id = {choose}";
                }

                using (MySqlCommand command = new MySqlCommand(query, _config.StableConnect()))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player.Hp = reader.GetInt32(reader.GetOrdinal("Hp"));
                            player.Mana = reader.GetInt32(reader.GetOrdinal("Mana"));
                            player.AttackPower = reader.GetInt32(reader.GetOrdinal("AttackPower"));
                            player.Money = reader.GetInt32(reader.GetOrdinal("Money"));
                            player.HpPotion = reader.GetInt32(reader.GetOrdinal("HpPotion"));
                            player.PowerPotion = reader.GetInt32(reader.GetOrdinal("PowerPotion"));
                            player.PlayerName = reader.GetString(reader.GetOrdinal("PlayerName"));
                            Console.WriteLine($"Pozice s ID {choose} byla úspěšně načtena.");
                            Thread.Sleep(1500);
                            player.StartLoad = false;
                        }
                    }
                }
            }

            if (choose == 0 && player.StartLoad)
            {
                player.NewPlayer(player);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}