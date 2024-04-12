using Etermium.Entits;
using Etermium.Entity;
using Etermium.Print_out;

namespace Etermium.ICommand.GameMenu;

public class BossBattle : ICommand
{
    [Obsolete("Obsolete")]
    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
        EnemyPicture.DragonPicture();
        enemy.Boss(enemy, player);
        start_and_config.GameMenu.IsPlaying = false;
    }
}