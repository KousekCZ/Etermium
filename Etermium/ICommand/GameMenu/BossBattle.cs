using Etermium.Entits;
using System;
using System.Threading;
using Etermium.PrintOut;

namespace Etermium.ICommand.GameMenu;

/// <summary>
/// Class representing the command to initiate a boss battle in the game.
/// </summary>
public class BossBattle : ICommand
{
    /// <summary>
    /// Executes the command to start a boss battle.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    [Obsolete("Obsolete")]
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();
        Pictures.DragonPicture();
        enemy.Boss(enemy, player);
        Start_Config.GameMenu.IsPlaying = false;
    }
}