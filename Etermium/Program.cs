using System;
using Etermium.Start_Config;

namespace Etermium;

internal abstract class Program
{
    [Obsolete("Obsolete")]
    public static void Main(string[] args)
    {
        var gameMenu = new GameMenu();
        if (gameMenu == null)
        {
            throw new ArgumentNullException(nameof(gameMenu));
        }
    }
}