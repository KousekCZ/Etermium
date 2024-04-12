using Etermium.Entits;
using Etermium.Entity;
using Etermium.Mechanic;

namespace Etermium.ICommand.CSV;

public class CsvMoveDown : ICommand
{
    public void Execute(Player player, Enemy enemy)
    {
        try
        {
            CsvMap.CurrentRow += 1;
            CsvMap.CurrentPositionPlayer(CsvMap.CurrentRow, CsvMap.CurrentColumn);
        }
        catch (Exception)
        {
            CsvMap.CurrentRow -= 1;
            Console.WriteLine("Jsi mimo mapu, byl jsi vrácen na stejné místo.\n");
            CsvMap.K = 0;
        }
    }
}