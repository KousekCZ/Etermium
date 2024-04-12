using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.GameMenu;

public class ExitGame : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        Console.Clear();
        start_and_config.GameMenu.NewFrame();
        Console.WriteLine();
        start_and_config.GameMenu.IsPlaying = false;
    }
}