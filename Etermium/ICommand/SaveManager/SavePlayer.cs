using Etermium.Entits;
using MySqlConnector;
using System;
using System.Threading;
using Etermium.Start_Config;

namespace Etermium.ICommand.SaveManager;

/// <summary>
/// Represents the command to save the player's game progress.
/// </summary>
public class SavePlayer : ICommand
{
    private static readonly DatabaseConfig Config = new();

    /// <summary>
    /// Executes the command to save the player's game progress.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();

        var query =
            $"insert into {player.PlayerName} (Hp, Mana, AttackPower, Money, HpPotion, PowerPotion, PlayerName) values(@Hp, @Mana, @AttackPower, @Money, @HpPotion, @PowerPotion, @PlayerName);";
        using (MySqlCommand command = new MySqlCommand(query, Config.StableConnect()))
        {
            command.Parameters.AddWithValue("@Hp", player.Hp);
            command.Parameters.AddWithValue("@Mana", player.Mana);
            command.Parameters.AddWithValue("@AttackPower", player.AttackPower);
            command.Parameters.AddWithValue("@Money", player.Money);
            command.Parameters.AddWithValue("@HpPotion", player.HpPotion);
            command.Parameters.AddWithValue("@PowerPotion", player.PowerPotion);
            command.Parameters.AddWithValue("@PlayerName", player.PlayerName);
            command.ExecuteNonQuery();
        }

        Start_Config.GameMenu.NewFrame();
        var t = new Thread(Saving);
        t.Start();
        t.Join();
    }

    /// <summary>
    /// Method that simulates the saving process with dots and displays a success message.
    /// </summary>
    private static void Saving()
    {
        try
        {
            Console.Write("\nUkládání");
            Thread.Sleep(700);

            Console.Write(".");
            Thread.Sleep(700);

            Console.Write(".");
            Thread.Sleep(700);

            Console.Write(".");
            Thread.Sleep(700);

            Start_Config.GameMenu.NewFrame();
            Console.WriteLine("Postava byla uložena");
            Thread.Sleep(1500);
            Start_Config.GameMenu.NewFrame();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}