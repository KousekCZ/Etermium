using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand;

public interface ICommand
{
    void Execute(Player player, Enemy enemy);
}