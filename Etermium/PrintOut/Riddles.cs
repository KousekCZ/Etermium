using Etermium.Entits;
using Etermium.Start_Config;
using System;
using System.Threading;

namespace Etermium.PrintOut;

/// <summary>
/// Class responsible for handling riddles presented to the player.
/// </summary>
public class Riddles
{
    private bool _isGuessing = true;
    private string _answer = "";
    private int _attempt = 3;
    private static int _newMoney;
    private readonly Random _rd = new();

    /// <summary>
    /// Presents the first riddle to the player.
    /// </summary>
    /// <param name="player">The player object.</param>
    public void Riddle1(Player player)
    {
        Console.WriteLine(
            $"Dostaneš hádanku, pokud uhodneš, dostaneš odměnu. Máš {_attempt} pokusů.");

        Thread.Sleep(2000);
        while (_isGuessing)
        {
            Console.WriteLine(
                "\nKořeny má skryté v zemi, vypíná se nad jedlemi, stoupá pořád výš a výš, ale růst ji nevidíš. ~ Hobit, Co je to?");
            _answer = Console.ReadLine()!.Trim();
            if (_answer.Equals("hora", StringComparison.OrdinalIgnoreCase))
            {
                _newMoney = _rd.Next(10, 45);
                Console.WriteLine("Uhodl/a jsi, dostáváš odměnu v podobě " + _newMoney + "$");
                player.Money += _newMoney;
                _isGuessing = false;
                Thread.Sleep(2000);
            }
            else
            {
                _attempt--;
                Console.WriteLine("Špatně, zbývájí ti " + _attempt + " pokusy.");
                Thread.Sleep(2000);
            }

            if (_attempt == 0)
            {
                Console.WriteLine(
                    "Škoda, pokud chceš zjistit odpověď, zkus si přečíst, nebo poslechnout audio knihu \"Hobit\" - vracíš se do menu.");
                _isGuessing = false;
                Thread.Sleep(5000);
            }
        }

        GameMenu.NewFrame();
    }

    /// <summary>
    /// Presents the second riddle to the player.
    /// </summary>
    /// <param name="player">The player object.</param>
    public void Riddle2(Player player)
    {
        Console.WriteLine(
            $"Dostaneš hádanku, pokud uhodneš, dostaneš odměnu. Máš {_attempt} pokusů.");

        Thread.Sleep(2000);
        while (_isGuessing)
        {
            Console.WriteLine(
                "\n32 běloušů na rudé líše, napřed žvýkají, podom dupají a pak stojí tiše ~ Hobit, Co je to?");
            _answer = Console.ReadLine()!.Trim();
            if (_answer.Equals("zuby", StringComparison.OrdinalIgnoreCase))
            {
                _newMoney = _rd.Next(10, 45);
                Console.WriteLine("Uhodl/a jsi, dostáváš odměnu v podobě " + _newMoney + "$");
                player.Money += _newMoney;
                _isGuessing = false;
                Thread.Sleep(2000);
            }
            else
            {
                _attempt--;
                Console.WriteLine("Špatně, zbývají ti " + _attempt + " pokusy.");
                Thread.Sleep(2000);
            }

            if (_attempt == 0)
            {
                Console.WriteLine(
                    "Škoda, pokud chceš zjistit odpověď, zkus si přečíst, nebo poslechnout audio knihu \"Hobit\" - vracíš se do menu.");
                _isGuessing = false;
                Thread.Sleep(5000);
            }
        }

        GameMenu.NewFrame();
    }

    /// <summary>
    /// Presents the third riddle to the player.
    /// </summary>
    /// <param name="player">The player object.</param>
    public void Riddle3(Player player)
    {
        Console.WriteLine(
            $"Dostaneš hádanku, pokud uhodneš, dostaneš odměnu. Máš {_attempt} pokusů.");

        Thread.Sleep(2000);
        while (_isGuessing)
        {
            Console.WriteLine(
                "\nSem dáváno a sem bráno, bylo jsem s tvým prvním nadechnutím, nežádala sis mě, ale budu s tebou až do smrti. ~ V zajetí démonu II, Co je to?");
            Console.WriteLine("Nepsat háčky a čárky u odpovědi.");
            _answer = Console.ReadLine()!.Trim();
            if (_answer.Equals("jméno", StringComparison.OrdinalIgnoreCase) ||
                _answer.Equals("jmeno", StringComparison.OrdinalIgnoreCase))
            {
                _newMoney = _rd.Next(10, 45);
                Console.WriteLine("Uhodl/a jsi, dostáváš odměnu v podobě " + _newMoney + "$");
                player.Money += _newMoney;
                _isGuessing = false;
                Thread.Sleep(2000);
            }
            else
            {
                _attempt--;
                Console.WriteLine("Špatně, zbývájí ti " + _attempt + " pokusy.");
                Thread.Sleep(2000);
            }

            if (_attempt == 0)
            {
                Console.WriteLine(
                    "Škoda, pokud chceš zjistit odpověď, zkus se podívat na film \"V zajetí démonu II\" - vracíš se do menu.");
                _isGuessing = false;
                Thread.Sleep(5000);
            }
        }

        GameMenu.NewFrame();
    }

    /// <summary>
    /// Presents the fourth riddle to the player.
    /// </summary>
    /// <param name="player">The player object.</param>
    public void Riddle4(Player player)
    {
        Console.WriteLine(
            $"Dostaneš hádanku, pokud uhodneš, dostaneš odměnu. Máš {_attempt} pokusů.");

        Thread.Sleep(2000);
        while (_isGuessing)
        {
            Console.WriteLine(
                "\nMá to zuby, ale nic to nejí, Co je to?");
            Console.WriteLine("Nepsat háčky a čárky u odpovědi.");
            _answer = Console.ReadLine()!.Trim();
            if (_answer.Equals("pila", StringComparison.OrdinalIgnoreCase))
            {
                _newMoney = _rd.Next(10, 45);
                Console.WriteLine("Uhodl/a jsi, dostáváš odměnu v podobě " + _newMoney + "$");
                player.Money += _newMoney;
                _isGuessing = false;
                Thread.Sleep(2000);
            }
            else
            {
                _attempt--;
                Console.WriteLine("Špatně, zbývájí ti " + _attempt + " pokusy.");
                Thread.Sleep(2000);
            }

            if (_attempt == 0)
            {
                Console.WriteLine(
                    "Škoda, správná odpoveď: \"pila\" - vracíš se do menu.");
                _isGuessing = false;
                Thread.Sleep(5000);
            }
        }

        GameMenu.NewFrame();
    }

    /// <summary>
    /// Presents the fifth riddle to the player.
    /// </summary>
    /// <param name="player">The player object.</param>
    public void Riddle5(Player player)
    {
        Console.WriteLine(
            $"Dostaneš hádanku, pokud uhodneš, dostaneš odměnu. Máš {_attempt} pokusů.");

        Thread.Sleep(2000);
        while (_isGuessing)
        {
            Console.WriteLine(
                "\nNemá ruce, nemá nohy, a přece vrata otevírá. Co je to?");
            Console.WriteLine("Nepsat háčky a čárky u odpovědi.");
            _answer = Console.ReadLine()!.Trim();
            if (_answer.Equals("vítr", StringComparison.OrdinalIgnoreCase) ||
                _answer.Equals("vitr", StringComparison.OrdinalIgnoreCase))
            {
                _newMoney = _rd.Next(10, 45);
                Console.WriteLine("Uhodl/a jsi, dostáváš odměnu v podobě " + _newMoney + "$");
                player.Money += _newMoney;
                _isGuessing = false;
                Thread.Sleep(2000);
            }
            else
            {
                _attempt--;
                Console.WriteLine("Špatně, zbývájí ti " + _attempt + " pokusy.");
                Thread.Sleep(2000);
            }

            if (_attempt == 0)
            {
                Console.WriteLine(
                    "Škoda, správná odpověď \"vítr\" - vracíš se do menu.");
                _isGuessing = false;
                Thread.Sleep(5000);
            }
        }

        GameMenu.NewFrame();
    }

    /// <summary>
    /// Presents the sixth riddle to the player.
    /// </summary>
    /// <param name="player">The player object.</param>
    public void Riddle6(Player player)
    {
        Console.WriteLine(
            $"Dostaneš hádanku, pokud uhodneš, dostaneš odměnu. Máš {_attempt} pokusů.");

        Thread.Sleep(2000);
        while (_isGuessing)
        {
            Console.WriteLine(
                "\nVisí to a neví kde, bije to a neví koho, ukazuje to a neví kam, počítá to, neví kolik. Co je to?");
            Console.WriteLine("Nepsat háčky a čárky u odpovědi.");
            _answer = Console.ReadLine()!.Trim();
            if (_answer.Equals("hodiny", StringComparison.OrdinalIgnoreCase))
            {
                _newMoney = _rd.Next(10, 45);
                Console.WriteLine("Uhodl/a jsi, dostáváš odměnu v podobě " + _newMoney + "$");
                player.Money += _newMoney;
                _isGuessing = false;
                Thread.Sleep(2000);
            }
            else
            {
                _attempt--;
                Console.WriteLine("Špatně, zbývájí ti " + _attempt + " pokusy.");
                Thread.Sleep(2000);
            }

            if (_attempt == 0)
            {
                Console.WriteLine(
                    "Škoda, správná odpověď: \"hodiny\" - vracíš se do menu.");
                _isGuessing = false;
                Thread.Sleep(5000);
            }
        }

        GameMenu.NewFrame();
    }

    /// <summary>
    /// Presents the seventh riddle to the player.
    /// </summary>
    /// <param name="player">The player object.</param>
    public void Riddle7(Player player)
    {
        Console.WriteLine(
            $"Dostaneš hádanku, pokud uhodneš, dostaneš odměnu. Máš {_attempt} pokusů.");

        Thread.Sleep(2000);
        while (_isGuessing)
        {
            Console.WriteLine(
                "\nMá města, ale ne domy. Má hory, ale ne stromy. Má řeky, ale ne ryby. Co je to?");
            Console.WriteLine("Nepsat háčky a čárky u odpovědi.");
            _answer = Console.ReadLine()!.Trim();
            if (_answer.Equals("mapa", StringComparison.OrdinalIgnoreCase))
            {
                _newMoney = _rd.Next(10, 45);
                Console.WriteLine("Uhodl/a jsi, dostáváš odměnu v podobě " + _newMoney + "$");
                player.Money += _newMoney;
                _isGuessing = false;
                Thread.Sleep(2000);
            }
            else
            {
                _attempt--;
                Console.WriteLine("Špatně, zbývájí ti " + _attempt + " pokusy.");
                Thread.Sleep(2000);
            }

            if (_attempt == 0)
            {
                Console.WriteLine(
                    "Škoda, správná odpoveď: \"mapa\" - vracíš se do menu.");
                _isGuessing = false;
                Thread.Sleep(5000);
            }
        }

        GameMenu.NewFrame();
    }
}