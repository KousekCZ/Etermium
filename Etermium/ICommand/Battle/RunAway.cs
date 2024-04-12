using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Battle;

public class RunAway : ICommand
{
    private readonly Random _rd = new();

    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();

        if (enemy.BossEnd)
        {
            Console.WriteLine("Při bojování s bossem nemůžeš utéct.");
            Thread.Sleep(2000);
        }
        else
        {
            Console.WriteLine("\nHráč/ka " + player.PlayerName + " se pokouší utéct.");
            Thread.Sleep(1500);
            var random = _rd.Next(2);
            if (random == 1)
            {
                Console.WriteLine("Máš štěstí! Utíkáš z boje. Vracíš se do menu.");
            }
            else
            {
                Console.WriteLine("Máš smůlu, při útěku jsi obdržel dmg.");
                var randomDmg = _rd.Next(1, 11);
                player.Hp = player.Hp - enemy.AttackPower - randomDmg;
            }

            Thread.Sleep(2000);
            Mechanic.Battle.IsFighting = false;
        }
    }
}