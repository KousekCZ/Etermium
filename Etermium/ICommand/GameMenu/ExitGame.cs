using Etermium.Entits;
using Etermium.ICommand.SaveManager;
using System;
using System.Threading;

namespace Etermium.ICommand.GameMenu;

/// <summary>
/// Class representing the command to exit the game.
/// </summary>
public class ExitGame : ICommand
{
    private readonly SavePlayer _savePlayer = new();

    /// <summary>
    /// Executes the command to exit the game.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Console.Clear();
        string? choose;
        do
        {
            Console.WriteLine("Chceš uložit hru? (ano/ne)");
            choose = Console.ReadLine();
        } while (!choose!.Equals("ano", StringComparison.OrdinalIgnoreCase) &&
                 !choose.Equals("a", StringComparison.OrdinalIgnoreCase) &&
                 !choose.Equals("ne", StringComparison.OrdinalIgnoreCase) &&
                 !choose.Equals("n", StringComparison.OrdinalIgnoreCase));

        if (choose.Equals("ano", StringComparison.OrdinalIgnoreCase) ||
            choose.Equals("a", StringComparison.OrdinalIgnoreCase))
        {
            _savePlayer.Execute(player, null);
        }

        Start_Config.GameMenu.NewFrame();
        Console.WriteLine();
        Start_Config.GameMenu.IsPlaying = false;
    }
}