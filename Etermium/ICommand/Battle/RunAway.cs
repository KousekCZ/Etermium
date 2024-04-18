using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Battle;

/// <summary>
/// Command for executing a run away action during battle.
/// </summary>
public class RunAway : ICommand
{
    private readonly Random _rd = new();

    /// <summary>
    /// Executes the run away command.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();

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