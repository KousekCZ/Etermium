using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Dealer;

/// <summary>
/// Command for buying health potions.
/// </summary>
public class BuyHpPotion : ICommand
{
    /// <summary>
    /// Executes the command to buy health potions.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        if (player.Money >= Mechanic.Dealer.PriceHpPotion)
        {
            Console.Write("\nKoupil/a jsi si lektvar na životy.");
            player.HpPotion += 1;
            Console.WriteLine(" Právě jich máš: " + player.HpPotion);
            player.Money -= Mechanic.Dealer.PriceHpPotion;
            Console.WriteLine("D kuji za nákup.");
            Thread.Sleep(2000);
            Start_Config.GameMenu.NewFrame();
        }
        else
        {
            Console.WriteLine("Na tento nákup máš málo peněz.");
            Thread.Sleep(2000);
        }
    }
}