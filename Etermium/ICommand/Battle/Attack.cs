using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Battle;

/// <summary>
/// Command for executing a standard attack during battle.
/// </summary>
public class Attack : ICommand
{
    private readonly Random _rd = new();

    /// <summary>
    /// Executes the attack command.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        if (Mechanic.Battle.UpPowerCount >= 1)
        {
            Start_Config.GameMenu.NewFrame();
            Console.WriteLine(
                "\nHráč/ka " + player.PlayerName + " útočí na jeden tah za " + player.AttackPower + " dmg");
            enemy.Hp -= player.AttackPower;
            Thread.Sleep(1500);
            Console.WriteLine("Nepřítel " + enemy.Name + " útočí za " + enemy.AttackPower + " dmg");
            player.Hp -= enemy.AttackPower;
            Thread.Sleep(1500);
            Mechanic.Battle.UpPowerCount--;
        }
        else
        {
            Start_Config.GameMenu.NewFrame();
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