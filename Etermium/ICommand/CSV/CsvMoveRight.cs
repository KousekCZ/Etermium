using Etermium.Entits;
using Etermium.Mechanic;
using System;
using System.Threading;

namespace Etermium.ICommand.CSV;

/// <summary>
/// Command for moving the player right in the CSV mini-game.
/// </summary>
public class CsvMoveRight : ICommand
{
    /// <summary>
    /// Executes the command to move the player right in the CSV mini-game.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        try
        {
            CsvMap.CurrentColumn += 1;
            CsvMap.CurrentPositionPlayer(CsvMap.CurrentRow, CsvMap.CurrentColumn);
        }
        catch (Exception)
        {
            CsvMap.CurrentColumn -= 1;
            Console.WriteLine("Jsi mimo mapu, byl jsi vrácen na stejné místo.\n");
            CsvMap.K = 0;
        }
    }
}