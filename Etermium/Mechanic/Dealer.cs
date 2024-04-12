using Etermium.Entits;
using Etermium.Entity;
using Etermium.ICommand.Dealer;
using Etermium.start_and_config;

namespace Etermium.Mechanic;

public class Dealer
{
    public static int PriceHp { get; set; } = 12;
    public static int PricePower { get; set; } = 15;
    public static int PriceHpPotion { get; set; } = 22;
    public static int PricePowerPotion { get; set; } = 30;
    public static bool IsBuying { get; set; }

    public void Trade(Player player)
    {
        IsBuying = true;
        while (IsBuying)
        {
            GameMenu.NewFrame();
            Console.WriteLine("\nVítej u obchodníka, Co chceš udělat? \n\nTvoje peníze: " + player.Money + "$"
                              + "\n1) Koupit si lepší meč - (zvedne sílu útoku o 5) - cena: " + PricePower + "$"
                              + "\n2) Koupit životy - (zvedne HP o 7) - cena: " + PriceHp + "$"
                              + "\n3) Koupit si lektvar na životy (lze použít při boji na zachránění) - cena: " +
                              PriceHpPotion + "$"
                              + "\n4) Koupit lektvar na sílu. Umožní dát jeden úder o 25 bodů větší silou, než je aktuální - cena: " +
                              PricePowerPotion + "$"
                              + "\n5) Odejít. ");
            var choose = Console.ReadLine()!.Trim();
            while (!choose.Equals("1") && !choose.Equals("2") && !choose.Equals("3") && !choose.Equals("4") &&
                   !choose.Equals("5"))
            {
                Console.Write("Taková voba v nabídce není, zkus to znovu: ");
                choose = Console.ReadLine()!.Trim();
            }

            var commands = new Dictionary<string, ICommand.ICommand>
            {
                { "1", new BuyHp() }, // Zvedne životy hráči
                { "2", new BuyPower() }, // zvedne sílu hráči
                { "3", new BuyHpPotion() }, // přidá lektvar na životy
                { "4", new BuyPowerPotion() }, // přidá lektvar na sílu
                { "5", new Exit() } // přidá lektvar na sílu
            };

            ICommand.ICommand command;
            if (commands.TryGetValue(choose, out command!)) command.Execute(player, null);
        }
    }
}