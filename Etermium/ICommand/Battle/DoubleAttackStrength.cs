using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.Battle;

public class DoubleAttackStrength : ICommand
{
    private readonly Random _rd = new();

    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
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