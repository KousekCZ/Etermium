namespace Etermium.Mechanic;

using System;
using System.Threading;

/// <summary>
/// Class responsible for changing the console text color in a random manner.
/// </summary>
public abstract class RgbConsole
{
    /// <summary>
    /// Randomly changes the console text color.
    /// </summary>
    public static void Rgb()
    {
        var t = new Thread(() =>
        {
            while (true)
            {
                var rd = new Random();

                var barva = rd.Next(1, 9);

                switch (barva)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                Thread.Sleep(1);
            }
        });

        t.Start();
    }
}