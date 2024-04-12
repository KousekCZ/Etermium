using Etermium.Entits;
using Etermium.Entity;
using Etermium.start_and_config;
using MySqlConnector;

namespace Etermium.ICommand.SaveManager;

public class SavePlayer : ICommand
{
    private static readonly DatabaseConfig Config = new();

    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();

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

        start_and_config.GameMenu.NewFrame();
        var t = new Thread(Saving);
        t.Start();
        t.Join();
    }

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

            start_and_config.GameMenu.NewFrame();
            Console.WriteLine("Postava byla uložena");
            Thread.Sleep(1500);
            start_and_config.GameMenu.NewFrame();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}