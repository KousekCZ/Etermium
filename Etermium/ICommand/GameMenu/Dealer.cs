using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.GameMenu;

public class Dealer : ICommand
{
    private readonly Mechanic.Dealer _dealer = new();
    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
        Console.WriteLine();
        _dealer.Trade(player);
    }
}