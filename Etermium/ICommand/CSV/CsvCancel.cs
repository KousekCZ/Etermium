using Etermium.Entits;
using Etermium.Mechanic;
using System;
using System.Threading;

namespace Etermium.ICommand.CSV;

/// <summary>
/// Command for canceling the CSV mini-game.
/// </summary>
public class CsvCancel : ICommand
{
    /// <summary>
    /// Executes the command to cancel the CSV mini-game.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();
        Console.WriteLine("Škoda, budeš vrácen do nabídky možností bez odměny");
        Thread.Sleep(3000);
        Start_Config.GameMenu.NewFrame();

        CsvMap.IsFinding = false;
    }
}