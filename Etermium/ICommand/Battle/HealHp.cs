using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Battle;

/// <summary>
/// Command for executing a heal HP action during battle.
/// </summary>
public class HealHp : ICommand
{
    /// <summary>
    /// Executes the heal HP command.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();
        if (player.HpPotion >= 1)
        {
            if (player.Mana >= 5)
            {
                Console.WriteLine("\nPoužíváš lektvar na životy.");
                Thread.Sleep(1500);
                Console.Write("Životy se ti zvedly z " + player.Hp);
                player.Hp += Mechanic.Battle.UpHp;
                Console.WriteLine(" HP na: " + player.Hp + " HP.");
                player.HpPotion -= 1;
                player.Mana -= 8;
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("\nNemáš dostatek many.");
                Thread.Sleep(2000);
            }
        }
        else
        {
            Console.WriteLine("\nNemáš dostatek HP lektvarů.");
            Thread.Sleep(2000);
        }
    }
}