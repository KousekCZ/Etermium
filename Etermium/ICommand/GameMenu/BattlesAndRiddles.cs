using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.GameMenu;

/// <summary>
/// Class representing the command to initiate battles and riddles in the game.
/// </summary>
public class BattlesAndRiddles : ICommand
{
    /// <summary>
    /// Executes the command to start a battle or a riddle.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    [Obsolete("Obsolete")]
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();
        enemy.GenerateBattleOrRiddle(enemy, player);
        if (player.Hp <= 0)
        {
            Start_Config.GameMenu.IsPlaying = false;
        }
    }
}