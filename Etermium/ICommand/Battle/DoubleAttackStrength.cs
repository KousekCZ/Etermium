using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.Battle;

/// <summary>
/// Command for executing a double attack strength during battle.
/// </summary>
public class DoubleAttackStrength : ICommand
{
    private readonly Random _rd = new();

    /// <summary>
    /// Executes the double attack strength command.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        Start_Config.GameMenu.NewFrame();
        Console.WriteLine("\nHráč/ka " + player.PlayerName +
                          " se pokouší vyhnout a udělit větší dmg.");
        Thread.Sleep(1500);
        int tmpDmg;
        var pokus = _rd.Next(2);
        if (pokus == 1)
        {
            tmpDmg = player.AttackPower * 2;
            Console.WriteLine(
                "Máš štěstí! Vyhýbáš se nepříteli a uděluješ mu 2x více dmg, takže celkem " + tmpDmg);
            enemy.Hp -= tmpDmg;
        }
        else
        {
            tmpDmg = enemy.AttackPower * 2;
            Console.WriteLine("Máš smůlu, nepřítel se jménem: " + enemy.Name +
                              "ti uděluje 2x více dmg, takže celkem " + tmpDmg);
            player.Hp -= tmpDmg;
        }

        player.Mana += _rd.Next(5, 20);
        Thread.Sleep(2000);
    }
}