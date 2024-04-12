using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Battle;

public class HealHp : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
        if (player.HpPotion >= 1)
        {
            if (player.Mana >= 5)
            {
                Console.WriteLine("\nPoužíváš lektvar na životy.");
                Thread.Sleep(1500);
                Console.Write("Životy se ti zvedly z " + player.Hp);
                player.Hp += Mechanic.Battle.UpHp;
                Console.WriteLine(" HP na: " + player.Hp + " HP.");
                player.HpPotion -= 1;
                player.Mana -= 8;
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
            Console.WriteLine("\nNemáš dostatek HP lektvarů.");
            Thread.Sleep(2000);
        }
    }
}