using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Dealer;

public class BuyPowerPotion : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        if (player.Money >= Mechanic.Dealer.PricePowerPotion)
        {
            Console.Write("\nKoupil/a jsi si lektvar na sílu.");
            player.PowerPotion += 1;
            Console.WriteLine(" Právě jich máš: " + player.PowerPotion);
            player.Money -= Mechanic.Dealer.PricePowerPotion;
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