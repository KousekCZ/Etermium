using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Dealer;

/// <summary>
/// Command for buying health points (HP).
/// </summary>
public class BuyHp : ICommand
{
    /// <summary>
    /// Executes the command to buy health points (HP).
    /// </summary>
    /// <param name="player">The player object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        if (player.Money >= Mechanic.Dealer.PriceHp)
        {
            Console.Write("\nTvoje životy se zvedly z " + player.Hp);
            player.Hp += 7;
            Console.WriteLine(" na: " + player.Hp + ".");
            player.Money -= Mechanic.Dealer.PricePower;
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