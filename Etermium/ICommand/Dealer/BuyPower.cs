using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Dealer;

/// <summary>
/// Command for buying power upgrades.
/// </summary>
public class BuyPower : ICommand
{
    /// <summary>
    /// Executes the command to buy power upgrades.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        if (player.Money >= Mechanic.Dealer.PricePower)
        {
            Console.Write("\nTvoje síla útoku se zvedla z " + player.AttackPower);
            player.AttackPower += 5;
            Console.WriteLine(" na: " + player.AttackPower + ".");
            player.Money -= Mechanic.Dealer.PriceHp;
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