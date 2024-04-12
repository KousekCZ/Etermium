using Etermium.Entits;
using Etermium.Entity;
using Etermium.Mechanic;

namespace Etermium.ICommand.CSV;

public class CsvMoveRight : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        try
        {
            CsvMap.CurrentColumn += 1;
            CsvMap.CurrentPositionPlayer(CsvMap.CurrentRow, CsvMap.CurrentColumn);
        }
        catch (Exception)
        {
            CsvMap.CurrentColumn -= 1;
            Console.WriteLine("Jsi mimo mapu, byl jsi vrácen na stejné místo.\n");
            CsvMap.K = 0;
        }
    }
}