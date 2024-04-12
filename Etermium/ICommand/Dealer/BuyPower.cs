using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Dealer;

public class BuyPower : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        if (player.Money >= Mechanic.Dealer.PricePower)
        {
            Console.Write("\nTvoje síla útoku se zvedla z " + player.AttackPower);
            player.AttackPower += 5;
            Console.WriteLine(" na: " + player.AttackPower + ".");
            player.Money -= Mechanic.Dealer.PriceHp;
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