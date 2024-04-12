using Etermium.Entits;
using Etermium.Entity;
using Etermium.Print_out;

namespace Etermium.ICommand.GameMenu;

public class StoryAgain : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
        Console.WriteLine();
        AboutProgram.DontShowYouStoryAgain();
        Thread.Sleep(2000);
        start_and_config.GameMenu.NewFrame();
    }
}