using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Battle;

public class Attack : ICommand
{
    private readonly Random _rd = new();

    public void Execute(Player player, Enemy enemy)
    {
        if (Mechanic.Battle.UpPowerCount >= 1)
        {
            start_and_config.GameMenu.NewFrame();
            Console.WriteLine("\nHráč/ka " + player.PlayerName + " útočí na jeden tah za " + player.AttackPower + " dmg");
            enemy.Hp -= player.AttackPower;
            Thread.Sleep(1500);
            Console.WriteLine("Nepřítel " + enemy.Name + " útočí za " + enemy.AttackPower + " dmg");
            player.Hp -= enemy.AttackPower;
            Thread.Sleep(1500);
            Mechanic.Battle.UpPowerCount--;
        }
        else
        {
            start_and_config.GameMenu.NewFrame();
            Console.WriteLine("\nHráč/ka " + player.PlayerName + " útočí za " + player.AttackPower + " dmg");
            enemy.Hp -= player.AttackPower;
            Thread.Sleep(1500);
            Console.WriteLine("Nepřítel " + enemy.Name + " útočí za " + enemy.AttackPower + " dmg");
            player.Hp -= enemy.AttackPower;
            player.Mana += _rd.Next(5, 20);
            Thread.Sleep(1500);
        }
    }
}