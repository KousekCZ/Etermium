using Etermium.Entits;
using System;
using System.Threading;
using Etermium.PrintOut;

namespace Etermium.ICommand.GameMenu;

/// <summary>
/// Class representing the command for replaying the game story.
/// </summary>
public class StoryAgain : ICommand
{
    /// <summary>
    /// Executes the command for replaying the game story.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();
        Console.WriteLine();
        AboutProgram.DontShowYouStoryAgain();
        Thread.Sleep(2000);
        Start_Config.GameMenu.NewFrame();
    }
}