using Etermium.Entits;
using Etermium.Entity;

namespace Etermium.ICommand.GameMenu;

public class SaveManaging : ICommand
{
    private readonly Mechanic.SaveManager _saveManager = new();

    public void Execute(Player player, Enemy enemy)
    {
        _saveManager.IsSaving = true;
        _saveManager.ManageSave(player, enemy);
    }
}