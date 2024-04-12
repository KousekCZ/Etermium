using Etermium.start_and_config;

namespace Etermium;

internal abstract class Program
{
    [Obsolete("Obsolete")]
    public static void Main(string[] args)
    {
        new GameMenu();
    }
}