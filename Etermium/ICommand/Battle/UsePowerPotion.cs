using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Battle;

public class UsePowerPotion : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
        if (player.PowerPotion >= 1)
        {
            if (player.Mana >= 11)
            {
                Console.WriteLine("\nPoužíváš lektvar na sílu.");
                Thread.Sleep(1500);
                Console.Write("Síla se ti zvedla na jeden úder z " + player.AttackPower);

                if (Mechanic.Battle.UpPowerCount < 1) player.AttackPower += Mechanic.Battle.UpSila;

                Mechanic.Battle.UpPowerCount++;
                Console.WriteLine(" dmg na: " + player.AttackPower + " dmg.");
                player.PowerPotion -= 1;
                player.Mana -= 11;
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("\nNemáš dostatek many.");
                Thread.Sleep(2000);
            }
        }
        else
        {
            Console.WriteLine("\nNemáš dostatek Síla lektvarů.");
            Thread.Sleep(2000);
        }
    }
}