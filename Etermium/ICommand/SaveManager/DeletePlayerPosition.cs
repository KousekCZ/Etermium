using Etermium.Entits;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Threading;
using Etermium.Start_Config;

namespace Etermium.ICommand.SaveManager;

/// <summary>
/// Command for deleting a player's saved position.
/// </summary>
public class DeletePlayerPosition : ICommand
{
    private readonly DatabaseConfig _config = new();

    /// <summary>
    /// Executes the command to delete a player's saved position.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        try
        {
            var query =
                $"select id, Hp, Mana, AttackPower, Money, HpPotion, PowerPotion, Created from {player.PlayerName}";

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
                    SelectMessagesToDelete(id, player);
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Někde nastala chyba.");
        }
    }

    /// <summary>
    /// Allows the player to select a position to delete from the list of saved positions.
    /// </summary>
    /// <param name="id">The list of IDs of saved positions.</param>
    /// <param name="player">The player object.</param>
    private void SelectMessagesToDelete(List<int> id, Player player)
    {
        var choose = 0;
        try
        {
            do
            {
                try
                {
                    Console.Write("\nZadej ID pozice, kterou chceš smazat (nebo napiš '0' pro ukončení mazání): ");
                    choose = int.Parse(Console.ReadLine()!.Trim());

                    if (!id.Contains(choose) && choose != 0) Console.WriteLine("\nTakova pozice s ID neexistuje.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!id.Contains(choose) && choose != 0);

            if (choose != 0)
            {
                if (id.Count <= 1)
                {
                    Console.WriteLine("Nelze smazat poslední uloženou pozici.");
                    Thread.Sleep(1500);
                }
                else
                {
                    var query = $"DELETE FROM {player.PlayerName} WHERE id = {choose}";
                    using (MySqlCommand command = new MySqlCommand(query, _config.StableConnect()))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("\nPozice s id: " + choose + " byla úspěšně odstraněna.");
                    id.Remove(choose);
                    Thread.Sleep(2000);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Při mazání herní pozice {choose} nastala chyba: " + e.Message);
        }
    }
}