using Etermium.Entits;
using Etermium.ICommand.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Etermium.Start_Config;

namespace Etermium.Mechanic;

/// <summary>
/// Class for managing a mini-game involving movement in a maze represented by a CSV map.
/// </summary>
public class CsvMap
{
    private const string FilePath = "data/Mapa/mapa.csv";
    private static readonly string[,] PlayingArea = new string[9, 12];
    private static int _money;
    private int _pickHp;
    private int _pickStrengPotion;
    public static int CurrentRow { get; set; } = 2;
    public static int CurrentColumn { get; set; } = 8;
    public static int K { get; set; }
    public static bool IsFinding { get; set; } = true;

    /// <summary>
    /// Constructor for CsvMap class. Reads the CSV map file.
    /// </summary>
    public CsvMap()
    {
        ReadCsv();
    }

    /// <summary>
    /// Reads the CSV file containing the maze map data and initializes the PlayingArea array.
    /// </summary>
    private static void ReadCsv()
    {
        var data = new string[9, 12];
        try
        {
            using (var reader = new StreamReader(FilePath))
            {
                var row = 0;
                while (!reader.EndOfStream && row < data.GetLength(0))
                {
                    var line = reader.ReadLine();
                    var values = line!.Split(',');
                    for (var column = 0; column < data.GetLength(1) && column < values.Length; column++)
                    {
                        data[row, column] = values[column];
                    }

                    row++;
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Chyba při čtení souboru: " + e.Message);
        }

        for (var i = 0; i < PlayingArea.GetLength(0); i++)
        {
            for (var j = 0; j < PlayingArea.GetLength(1); j++)
            {
                PlayingArea[i, j] = data[i, j];
            }
        }
    }

    /// <summary>
    /// Shows the current state of the map.
    /// </summary>
    private static void ShowMap()
    {
        for (var i = 0; i < PlayingArea.GetLength(0); i++)
        {
            for (var j = 0; j < PlayingArea.GetLength(1); j++)
            {
                Console.Write(PlayingArea[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Displays the current position of the player on the map.
    /// </summary>
    /// <param name="i">The row index of the player's position.</param>
    /// <param name="j">The column index of the player's position.</param>
    public static void CurrentPositionPlayer(int i, int j)
    {
        Console.WriteLine("\n  " + PlayingArea[i - 1, j]);
        Console.WriteLine(PlayingArea[i, j - 1] + " " + PlayingArea[i, j] + " " + PlayingArea[i, j + 1]);
        Console.WriteLine("  " + PlayingArea[i + 1, j]);
    }

    /// <summary>
    /// Starts the mini-game where the player navigates through the maze and collects rewards.
    /// </summary>
    /// <param name="player">The player participating in the mini-game.</param>
    public void PlayMiniGame(Player player)
    {
        Console.Clear();
        Console.WriteLine("\nVítám tě v malém bludišti. Začínáš na pozici označené \"+\" a jsi vždy uprostřed. "
                          + "Můžeš se pohybovat do čtyř stran. "
                          + "\nTvým úkolem je dojít na místo, kde je políčko uprostřed prázdné. Poté dostaneš odměnu. Na mapě jsou také někde skryté odměny :)"
                          + "\n\nMožnosti pohybu: \nNahoru (W), \nDolu (S), \nDoleva (A), \nDoprava (D), \nskončit bez odměny (ukoncit)");

        while (IsFinding)
        {
            if (K != 1)
            {
                CurrentPositionPlayer(CurrentRow, CurrentColumn);
                K = 1;
            }

            var move = Console.ReadLine()?.Trim().ToLower();

            for (var i = 0; i < 11; i++)
            {
                Console.WriteLine();
            }

            var commands = new Dictionary<string, ICommand.ICommand>
            {
                { "w", new CsvMoveUp() }, // nahoru
                { "s", new CsvMoveDown() }, // dolu
                { "a", new CsvMoveLeft() }, // doleva
                { "d", new CsvMoveRight() }, // doprava
                { "ukoncit", new CsvCancel() } // ukoncit
            };

            ICommand.ICommand command;
            if (move != null && commands.TryGetValue(move, out command!))
            {
                command.Execute(player, null);
            }


            switch (CurrentRow)
            {
                // Kontroly jestli už je na místě, nmebo našel poklady
                case 1 when CurrentColumn == 1:
                {
                    if (_money == 0)
                    {
                        Console.WriteLine("\nVýborně, našel jsi peníze. Byly ti připsány k postavě");
                        player.Money += 18;
                        _money = 1;
                    }
                    else
                    {
                        Console.WriteLine("Tady už sis odměnu vyzvedl/a, pokračuj v hledání.");
                    }

                    break;
                }
                case 6 when CurrentColumn == 10:
                {
                    if (_pickHp == 0)
                    {
                        Console.WriteLine("\nVýborně, našel jsi lektvar na životy. Byly ti připsány k postavě");
                        player.HpPotion += 1;
                        _pickHp = 1;
                    }
                    else
                    {
                        Console.WriteLine("Tady už sis odměnu vyzvedl/a, pokračuj v hledání.");
                    }

                    break;
                }

                case 1 when CurrentColumn == 9:
                {
                    if (_pickStrengPotion == 0)
                    {
                        Console.WriteLine("\nVýborně, našel jsi lektvar na sílu. Byly ti připsány k postavě");
                        player.PowerPotion += 1;
                        _pickStrengPotion = 1;
                    }
                    else
                    {
                        Console.WriteLine("Tady už sis odměnu vyzvedl/a, pokračuj v hledání.");
                    }

                    break;
                }

                case 6 when CurrentColumn == 3:
                    Console.WriteLine("Gratuluji, našel jsi cestu. Dal jsem ti za odměnu nějaké peníze.");
                    player.Money += 30;
                    Console.WriteLine("Zde je celá  mapa: \n");
                    ShowMap();
                    Console.WriteLine("\nStiskni \"Enter\" pro pokračování");
                    Console.ReadKey();
                    IsFinding = false;
                    GameMenu.NewFrame();
                    break;
            }
        }
    }
}