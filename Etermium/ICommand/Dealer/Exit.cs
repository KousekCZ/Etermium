using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Dealer;

/// <summary>
/// Command for exiting the dealer menu.
/// </summary>
public class Exit : ICommand
{
    /// <summary>
    /// Executes the command to exit the dealer menu.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Console.WriteLine("Měj se hezky, zas se zastav.");
        Thread.Sleep(2000);
        Start_Config.GameMenu.NewFrame();
        Mechanic.Dealer.IsBuying = false;
    }
}