using Etermium.Entits;
using Etermium.ICommand.SaveManager;
using System;
using System.Collections.Generic;
using System.Threading;
using Etermium.Start_Config;

namespace Etermium.Mechanic;

/// <summary>
/// Class responsible for managing player save positions.
/// </summary>
public class SaveManager
{
    public bool IsSaving { get; set; } = true;

    /// <summary>
    /// Manages the saving of player positions.
    /// </summary>
    /// <param name="player">The player whose position is being managed.</param>
    /// <param name="enemy">The enemy being interacted with.</param>
    public void ManageSave(Player player, Enemy enemy)
    {
        while (IsSaving)
        {
            Console.Clear();
            Console.WriteLine(
                "\nNacházíš se ve správě uložených pozic, stiskni příslušné číslo, aby vykonalo akci:"
                + "\n1) Uložit aktuální pozici hráče. (bude provedeno ihned)" +
                "\n2) Načíst pozici hráče (aktuální se smaže). "
                + "\n3) Promazat uložené pozice."
                + "\n(u) Ukončit správu uložených pozic.");

            var choose = Console.ReadLine()!.Trim();

            while (!choose.Equals("1") && !choose.Equals("2") && !choose.Equals("3") && !choose.Equals("u"))
            {
                Console.Write("Taková volba v nabídce není, zkus to znovu: ");
                choose = Console.ReadLine()!.Trim();
            }

            var commands = new Dictionary<string, ICommand.ICommand>
            {
                { "1", new SavePlayer() }, // uložit pozici
                { "2", new LoadPlayer() }, // načíst pozici pozici
                { "3", new DeletePlayerPosition() } // smazat pozici pozici
            };

            ICommand.ICommand command;
            if (commands.TryGetValue(choose, out command!))
            {
                command.Execute(player, enemy);
            }

            if (choose.Equals("u", StringComparison.OrdinalIgnoreCase))
            {
                IsSaving = false;
                GameMenu.NewFrame();
            }
        }
    }
}