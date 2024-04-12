using Etermium.Entits;
using Etermium.Entity;
using Etermium.Mechanic;

namespace Etermium.ICommand.CSV;

public class CsvCancel : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        start_and_config.GameMenu.NewFrame();
        Console.WriteLine("Škoda, budeš vrácen do nabídky možností bez odměny");
        Thread.Sleep(3000);
        start_and_config.GameMenu.NewFrame();

        CsvMap.IsFinding = false;
    }
}