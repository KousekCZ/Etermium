using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.GameMenu;

/// <summary>
/// Class representing the command to interact with the dealer in the game menu.
/// </summary>
public class Dealer : ICommand
{
    private readonly Mechanic.Dealer _dealer = new();

    /// <summary>
    /// Executes the command to interact with the dealer.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();
        Console.WriteLine();
        _dealer.Trade(player);
    }
}