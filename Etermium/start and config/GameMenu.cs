using Etermium.Entits;
using Etermium.Entity;
using Etermium.ICommand.GameMenu;
using Etermium.Mechanic;
using Etermium.Print_out;
using Dealer = Etermium.ICommand.GameMenu.Dealer;

namespace Etermium.start_and_config;

public class GameMenu
{
    private readonly DatabaseConfig _config = new();
    private readonly Enemy _enemy = new();
    private readonly HomeGenerator _generator = new();
    private readonly Player _player = new();
    public static bool IsPlaying { get; set; } = true;

    [Obsolete("Obsolete")]
    public GameMenu()
    {
        long seconds = 0;
        var timeElapsed = new Thread(() =>
        {
            while (true)
            {
                seconds++;
                Thread.Sleep(1000);
            }
        });


        _config.CreateDatabase();
        _config.ImportData();
        timeElapsed.Start();
        Password.PPassword();

        var t1 = new Thread(_generator.Run); // Domov
        t1.Start();

        string music;
        string rgb = null!;

        do
        {
            Console.Write("Přeješ si mít hudbu ve hře? - 'Future is Now' (ano/ne): ");
            music = Console.ReadLine()!.Trim();
        } while (!music.Equals("ano", StringComparison.OrdinalIgnoreCase) &&
                 !music.Equals("a", StringComparison.OrdinalIgnoreCase) &&
                 !music.Equals("ne", StringComparison.OrdinalIgnoreCase) &&
                 !music.Equals("n", StringComparison.OrdinalIgnoreCase));

        do
        {
            Console.Write("Přeješ si mít RGB konzoli? (ano/ne): ");
            rgb = Console.ReadLine()!.Trim();
        } while (!rgb.Equals("ano", StringComparison.OrdinalIgnoreCase) &&
                 !rgb.Equals("a", StringComparison.OrdinalIgnoreCase) &&
                 !rgb.Equals("ne", StringComparison.OrdinalIgnoreCase) &&
                 !rgb.Equals("n", StringComparison.OrdinalIgnoreCase));

        if (music.Equals("ano", StringComparison.OrdinalIgnoreCase))
            MusicPlayer.Play("Data/Audio/Future Is Now.mp3", _enemy);

        Console.Clear();
        AboutProgram.BeginStory();

        if (rgb.Equals("ano", StringComparison.OrdinalIgnoreCase)) RgbConsole.Rgb();

        _player.NewPlayer(_player);
        NewFrame();

        Console.WriteLine("\n-------------------- Etermium ----------------------");
        Console.WriteLine("\nHraje hráč/ka: " + _player.PlayerName);

        Gameplay();

        var minutes = seconds / 60;
        var hours = minutes / 60;
        while (seconds > 60) seconds -= 60;

        Console.WriteLine("\nHrál/a jsi: " + hours + " hodin, " + minutes + " minut, " + seconds + " vteřin.");
        Console.WriteLine("\nStiskni \"Enter\" pro skončení hry.");

        Console.ReadKey();
        try
        {
            MusicPlayer.Stop();
        }
        catch (Exception)
        {
            Console.WriteLine();
        }
        Environment.Exit(0);
    }

    private void Gameplay()
    {
        while (IsPlaying)
        {
            _player.Print();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine(
                "\nNacházíš se v hlavním menu. Odtud vedou všechny cesty. \nCo si přeješ udělat? (Zadej číslo)"
                + "\n\n1) Přečíst si úvod znovu. " + "\n2) Jít k obchodníkovi. "
                + "\n3) Jít domu (zde se generují peníze)"
                + "\n4) Zkusit porazit bosse."
                + "\n5) Jít bojovat nebo hádat hádanky, kvízy (záleží, co ti program vybere :D)"
                + "\n6) Správa uložených pozic." + "\n7) Vypnout hru bez uložení.");

            var choose = Console.ReadLine()!.Trim();

            while (!choose.Equals("1") && !choose.Equals("2") && !choose.Equals("3") && !choose.Equals("4")
                   && !choose.Equals("5") && !choose.Equals("6") && !choose.Equals("7"))
            {
                Console.Write("Taková volba v nabídce není, zkus to znovu: ");
                choose = Console.ReadLine()!.Trim();
            }

            var commands = new Dictionary<string, ICommand.ICommand>
            {
                { "1", new StoryAgain() }, // Story_uvod
                { "2", new Dealer() }, // OBCHODNíK
                { "3", new Home() }, // DOMOV
                { "4", new BossBattle() }, // BOSS
                { "5", new BattlesAndRiddles() }, // SOUBOJE A LUŠTĚNÍ
                { "6", new SaveManaging() }, // SPRÁVA ULOŽENÍ
                { "7", new ExitGame() } // VYPNOUT HRU
            };

            ICommand.ICommand command;
            if (commands.TryGetValue(choose, out command!)) command.Execute(_player, _enemy);
        }
    }

    public static void NewFrame()
    {
        for (var i = 0; i < 100; i++) Console.WriteLine();
    }
}