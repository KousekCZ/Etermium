using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.GameMenu;

public class BattlesAndRiddles : ICommand
{
    [Obsolete("Obsolete")]
    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
        enemy.GenerateBattleOrRiddle(enemy, player);
        if (player.Hp <= 0) start_and_config.GameMenu.IsPlaying = false;
    }
}