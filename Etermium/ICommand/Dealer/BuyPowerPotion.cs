using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Dealer;

/// <summary>
/// Command for buying power potions.
/// </summary>
public class BuyPowerPotion : ICommand
{
    /// <summary>
    /// Executes the command to buy power potions.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        if (player.Money >= Mechanic.Dealer.PricePowerPotion)
        {
            Console.Write("\nKoupil/a jsi si lektvar na sílu.");
            player.PowerPotion += 1;
            Console.WriteLine(" Právě jich máš: " + player.PowerPotion);
            player.Money -= Mechanic.Dealer.PricePowerPotion;
            Console.WriteLine("Děkuji za nákup.");
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