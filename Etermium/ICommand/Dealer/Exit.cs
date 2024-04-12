using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Dealer;

public class Exit : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        Console.WriteLine("Měj se hezky, zas se zastav.");
        Thread.Sleep(2000);
        start_and_config.GameMenu.NewFrame();
        Mechanic.Dealer.IsBuying = false;
    }
}