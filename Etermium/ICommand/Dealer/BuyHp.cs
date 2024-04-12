using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Dealer;

public class BuyHp : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        if (player.Money >= Mechanic.Dealer.PriceHp)
        {
            Console.Write("\nTvoje životy se zvedly z " + player.Hp);
            player.Hp += 7;
            Console.WriteLine(" na: " + player.Hp + ".");
            player.Money -= Mechanic.Dealer.PricePower;
            Console.WriteLine("Děkuji za nákup.");
            Thread.Sleep(2000);
            start_and_config.GameMenu.NewFrame();
        }
        else
        {
            Console.WriteLine("Na tento nákup máš málo peněz.");
            Thread.Sleep(2000);
        }
    }
}