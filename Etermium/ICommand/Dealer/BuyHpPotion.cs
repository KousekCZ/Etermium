using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Dealer;

public class BuyHpPotion : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        if (player.Money >= Mechanic.Dealer.PriceHpPotion)
        {
            Console.Write("\nKoupil/a jsi si lektvar na životy.");
            player.HpPotion += 1;
            Console.WriteLine(" Právě jich máš: " + player.HpPotion);
            player.Money -= Mechanic.Dealer.PriceHpPotion;
            Console.WriteLine("D kuji za nákup.");
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