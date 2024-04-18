using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand.GameMenu;

/// <summary>
/// Class representing the command for managing game saves.
/// </summary>
public class SaveManaging : ICommand
{
    private readonly Mechanic.SaveManager _saveManager = new();

    /// <summary>
    /// Executes the command for managing game saves.
    /// </summary>
    /// <param name="player">The player object.</param>
    /// <param name="enemy">The enemy object.</param>
    public void Execute(Player player, Enemy enemy)
    {
        _saveManager.IsSaving = true;
        _saveManager.ManageSave(player, enemy);
    }
}