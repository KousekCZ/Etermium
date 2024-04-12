using Etermium.Entits;
using Etermium.Entity;
using Etermium.ICommand.SaveManager;
using Etermium.start_and_config;

namespace Etermium.Mechanic;

public class SaveManager
{
    public bool IsSaving { get; set; } = true;

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

            var dotaz = Console.ReadLine()!.Trim();

            while (!dotaz.Equals("1") && !dotaz.Equals("2") && !dotaz.Equals("3") && !dotaz.Equals("u"))
            {
                Console.Write("Taková volba v nabídce není, zkus to znovu: ");
                dotaz = Console.ReadLine()!.Trim();
            }

            var commands = new Dictionary<string, ICommand.ICommand>
            {
                { "1", new SavePlayer() }, // uložit pozici
                { "2", new LoadPlayer() }, // načíst pozici pozici
                { "3", new DeletePlayerPosition() } // smazat pozici pozici
            };

            ICommand.ICommand command;
            if (commands.TryGetValue(dotaz, out command!)) command.Execute(player, enemy);

            if (dotaz.Equals("u", StringComparison.OrdinalIgnoreCase))
            {
                IsSaving = false;
                GameMenu.NewFrame();
            }
        }
    }
}